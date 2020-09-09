using BlazorShop.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorShop.Server.Data.Repositories.OrderProductRepository
{
    public class OrderProductRepository : Repository<OrderProduct>, IOrderProductRepository
    {
        protected BlazorShopContext BlazorShopContext => _context as BlazorShopContext;

        public OrderProductRepository(BlazorShopContext context) : base(context) { }
    }
}
