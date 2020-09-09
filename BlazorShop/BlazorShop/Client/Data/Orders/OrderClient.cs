using BlazorShop.Client.Helpers;
using BlazorShop.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorShop.Client.Data.Orders
{
    public class OrderClient : IOrderClient
    {
        private readonly IHttpService _httpService;
        private readonly string baseURL = "api/order";

        public OrderClient(IHttpService httpService)
        {
            this._httpService = httpService;
        }

        public async Task<int> Create(OrderSubmitDTO newOrder)
        {
            var response = await _httpService.Post<OrderSubmitDTO, int>(baseURL, newOrder);

            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }

            return response.Data;
        }

        public async Task<List<CustomerOrderViewModel>> GetAllByUser(int id)
        {
            var response = await _httpService.Get<List<CustomerOrderViewModel>>($"{baseURL}/byuser/{id}");

            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }

            return response.Data;
        }

        public async Task<List<ManagerOrderItemViewModel>> GetAllRequests()
        {
            var response = await _httpService.Get<List<ManagerOrderItemViewModel>>(baseURL);

            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }

            return response.Data;
        }

        public async Task<ManagerOrderViewModel> GetSingleRequest(int id)
        {
            var response = await _httpService.Get<ManagerOrderViewModel>($"{baseURL}/{id}");

            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }

            return response.Data;
        }

        public async Task UpdateOrderStatus(UpdateOrderStatusDTO orderToUpdate)
        {
            var response = await _httpService.Put<UpdateOrderStatusDTO>(baseURL, orderToUpdate);

            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }
    }
}
