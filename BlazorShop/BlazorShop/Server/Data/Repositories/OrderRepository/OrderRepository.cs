using BlazorShop.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorShop.Server.Data.Repositories.OrderRepository
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        protected BlazorShopContext BlazorShopContext => _context as BlazorShopContext;

        public OrderRepository(BlazorShopContext context) : base(context) { }

        public async Task<IEnumerable<Order>> GetAllByUser(int id)
        {
            return await _entities.Where(o => o.CustomerId == id)
                                  .Include(c => c.OrderProduct)
                                  .ThenInclude(op => op.Product)
                                  .ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetAllRequests()
        {
            return await _entities.Include(c => c.Customer)
                                  .Include(c => c.OrderProduct)
                                  .ToListAsync();
        }

        public async Task<Order> GetSingleRequest(int id)
        {
            return await _entities.Include(c => c.Customer)
                                  .Include(c => c.OrderProduct)
                                  .ThenInclude(op => op.Product)
                                  .FirstOrDefaultAsync(o => o.Id == id);
                                  
        }
    }
}
