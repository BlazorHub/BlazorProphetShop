using BlazorShop.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorShop.Server.Data.Repositories.ProductRepository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        protected BlazorShopContext BlazorShopContext => _context as BlazorShopContext;

        public ProductRepository(BlazorShopContext context) : base(context) { }

        public Task<IEnumerable<Product>> GetProductsByCategory(int id)
        {
            throw new NotImplementedException();
        }
    }
}
