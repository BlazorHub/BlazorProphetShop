using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BlazorShop.Server.Data;
using BlazorShop.Server.Data.Repositories.CategoryRepository;
using BlazorShop.Shared.DTOs.Category;
using BlazorShop.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorShop.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;
        private readonly BlazorShopContext _context;

        public CategoryController(ICategoryRepository repository,
                              IMapper mapper,
                              BlazorShopContext context)
        {
            _context = context;
            _mapper = mapper;
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Category> categories = _repository.GetAll().ToList();

            return Ok(_mapper.Map<List<GetCategoryDTO>>(categories));
        }
    }
}
