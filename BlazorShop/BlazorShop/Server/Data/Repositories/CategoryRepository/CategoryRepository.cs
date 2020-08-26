using BlazorShop.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorShop.Server.Data.Repositories.CategoryRepository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        protected BlazorShopContext BlazorShopContext => _context as BlazorShopContext;

        public CategoryRepository(BlazorShopContext context) : base(context) { }

        public async Task<int> CreateIfNotExists(string name)
        {
            var existingCategory = await BlazorShopContext.Category.SingleOrDefaultAsync(c => c.Name == name);

            if (existingCategory != null)
            {
                return existingCategory.Id;
            }
            else 
            {
                Category c = new Category
                {
                    Name = name,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };

                BlazorShopContext.Add(c);

                await BlazorShopContext.SaveChangesAsync();
                
                return c.Id;
            }
        }
    }
}
