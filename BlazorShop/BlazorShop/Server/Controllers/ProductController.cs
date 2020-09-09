using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BlazorShop.Server.Data;
using BlazorShop.Server.Data.Repositories.CategoryRepository;
using BlazorShop.Server.Data.Repositories.ProductRepository;
using BlazorShop.Server.Services.Storage;
using BlazorShop.Shared.DTOs;
using BlazorShop.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorShop.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IFileStorageService _azureStorage;
        private readonly IMapper _mapper;
        private readonly BlazorShopContext _context;

        public ProductController(IProductRepository repository, 
                                ICategoryRepository categoryRepository,
                                IFileStorageService azureStorage, 
                                IMapper mapper, 
                                BlazorShopContext context)
        {
            _context = context;
            _azureStorage = azureStorage;
            _mapper = mapper;
            _repository = repository;
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<Product> products = _context.Product.ToList();

            foreach (var p in products)
            {
                await _azureStorage.SaveFile(p.ImageContent, p.ImageName, "images");
            }

            return Ok(_mapper.Map<List<ProductViewModel>>(products));
        }


        [HttpGet("bycategory/{id}")]
        public async Task<IActionResult> GetAllByCategory([FromRoute] int id)
        {
            return Ok(await _repository.GetAllByCategory(id));
        }

        [HttpPost]
        public async Task<ActionResult<int>> Add(AddProductDTO newProduct)
        {
            var product = _mapper.Map<Product>(newProduct);
            product.CategoryId = await _categoryRepository.CreateIfNotExists(newProduct.CategoryName);

            _context.Product.Add(product);
            await _context.SaveChangesAsync();
            
            return Ok(product.Id);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Remove([FromRoute] int id)
        {
            var selectedProduct = await _context.Product.FirstOrDefaultAsync(pr => pr.Id == id);

            if (selectedProduct == null)
            {
                return NotFound();
            }

            _context.Remove(selectedProduct);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
