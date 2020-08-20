using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorShop.Server.Data;
using BlazorShop.Server.Data.Repositories.ProductRepository;
using BlazorShop.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorShop.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repository;
        private readonly BlazorShopContext _context;

        public ProductController(IProductRepository repository, BlazorShopContext context)
        {
            _context = context;
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAllProjects()
        {
            return Ok(_context.User.ToList());
        }
    }
}
