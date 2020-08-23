using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorShop.Server.Data;
using BlazorShop.Server.Data.Repositories.ProductRepository;
using BlazorShop.Server.Services.Storage;
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
        private readonly IFileStorageService _azureStorage;
        private readonly BlazorShopContext _context;

        public ProductController(IProductRepository repository, IFileStorageService azureStorage, BlazorShopContext context)
        {
            _context = context;
            _azureStorage = azureStorage;
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            List<Product> products = _context.Product.ToList();

            foreach (var p in products)
            {
                await _azureStorage.SaveFile(p.ImageContent, p.ImageName, "images");
            }

            return Ok(products);
        }
    }
}
