using BlazorShop.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorShop.Server.Data.Repositories.UserRepository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        protected BlazorShopContext BlazorShopContext => _context as BlazorShopContext;

        public UserRepository(BlazorShopContext context) : base(context) { }

        public async Task<User> GetSingleWithAddress(int id)
        {
            return await _entities.Include(u => u.Address)
                                  .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<List<User>> GetAllCustomers()
        {
            return await _entities.Where(u => u.Discriminator != "Manager").ToListAsync();
        }
    }
}
