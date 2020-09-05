using BlazorShop.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace BlazorShop.Server.Data.Repositories.ProductRepository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        protected BlazorShopContext BlazorShopContext => _context as BlazorShopContext;

        public ProductRepository(BlazorShopContext context) : base(context) { }

        public async Task<IEnumerable<Product>> GetProductsByCategory(int id)
        {
            return await _entities.Where(p => p.CategoryId == id).ToListAsync();
        }
    }
}
