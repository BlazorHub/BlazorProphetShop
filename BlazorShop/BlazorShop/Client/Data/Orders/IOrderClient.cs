using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorShop.Shared.ViewModels;
using BlazorShop.Shared.DTOs.Order;


namespace BlazorShop.Client.Data.Orders
{
    public interface IOrderClient
    {
        Task<List<ManagerOrderItemViewModel>> GetAllRequests();
        Task<ManagerOrderViewModel> GetSingleRequest(int id);
        Task<List<CustomerOrderViewModel>> GetAllByUser(int id);
        Task<int> Create(OrderSubmitDTO newOrder);
        Task UpdateOrderStatus(UpdateOrderStatusDTO orderToUpdate);
    }
}
