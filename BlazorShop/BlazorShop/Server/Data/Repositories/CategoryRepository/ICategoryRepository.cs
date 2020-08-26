using BlazorShop.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorShop.Server.Data.Repositories.CategoryRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<int> CreateIfNotExists(string name);
    }
}
