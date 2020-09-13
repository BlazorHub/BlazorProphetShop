using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BlazorShop.Server.Data;
using BlazorShop.Server.Data.Repositories.UserRepository;
using BlazorShop.Shared.DTOs.User;
using BlazorShop.Shared.Models;
using AutoMapper;

namespace BlazorShop.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        private readonly BlazorShopContext _context;

        public UserController(IUserRepository repository,
                              IMapper mapper,
                              BlazorShopContext context)
        {
            _context = context;
            _mapper = mapper;
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<User> customers = await _repository.GetAllCustomers();

            return Ok(_mapper.Map<List<GetUserDTO>>(customers));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingleUser([FromRoute] int id)
        {
            var user = await _repository.GetSingleWithAddress(id);

            return Ok(_mapper.Map<UpdateUserDTO>(user));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<int>> UpdateSingle([FromRoute] int id, UpdateUserDTO userToUpdate)
        {
            var existingUser = await _repository.GetSingleWithAddress(id);

            existingUser.Name = userToUpdate.Name;
            existingUser.Phone = userToUpdate.Phone;
            existingUser.Document = userToUpdate.Document;
            existingUser.Email = userToUpdate.Email;

            if (existingUser.Address == null)
            {
                existingUser.Address = new Address();
            }

            existingUser.Address.Name = userToUpdate.Address.Name;
            existingUser.Address.City = userToUpdate.Address.City;
            existingUser.Address.State = userToUpdate.Address.State;
            existingUser.Address.ZipCode = userToUpdate.Address.ZipCode;

            _context.Update(existingUser);
            await _context.SaveChangesAsync();

            return Ok(existingUser.Id);
        }

        [HttpPut("{id}/status")]
        public async Task<ActionResult<int>> UpdateSingleStatus([FromRoute] int id, UpdateUserStatusDTO userToUpdate)
        {
            var existingUser = await _repository.GetSingleWithAddress(id);

            existingUser.Enabled = userToUpdate.Enabled;
            _context.Update(existingUser);
            await _context.SaveChangesAsync();

            return Ok(existingUser.Id);
        }
    }
}
