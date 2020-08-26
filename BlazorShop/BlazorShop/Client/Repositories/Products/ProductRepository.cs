using BlazorShop.Client.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorShop.Shared.Models;
using BlazorShop.Shared.Http;
using BlazorShop.Shared.DTOs;

namespace BlazorShop.Client.Repositories.Products
{
    class ProductRepository : IProductRepository
    {
        private readonly IHttpService _httpService;
        private readonly string baseURL = "api/product";

        public ProductRepository(IHttpService httpService)
        {
            this._httpService = httpService;
        }

        public async Task<int> Add(AddProductDTO newProduct)
        {
            var response = await _httpService.Post<AddProductDTO, int>(baseURL, newProduct);

            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }

            return response.Data;
        }

        public async Task Delete(int productId)
        {
            var response = await _httpService.Delete($"{baseURL}/{productId}");

            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }

        public async Task<List<ProductViewModel>> GetAll()
        {
            var response = await _httpService.Get<List<ProductViewModel>>(baseURL);

            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }

            return response.Data;
        }

        public Task Update(AddProductDTO newProduct)
        {
            throw new NotImplementedException();
        }
    }
}
