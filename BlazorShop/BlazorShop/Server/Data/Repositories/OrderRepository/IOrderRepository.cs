using BlazorShop.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorShop.Server.Data.Repositories.OrderRepository
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<Order> GetSingleRequest(int id);
        Task<IEnumerable<Order>> GetAllRequests();
        Task<IEnumerable<Order>> GetAllByUser(int id);
    }
}
