using BlazorShop.Client.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorShop.Shared.Models;
using BlazorShop.Shared.Http;
using BlazorShop.Shared.DTOs.Product;
using BlazorShop.Shared.ViewModels;

namespace BlazorShop.Client.Data.Products
{
    class ProductClient : IProductClient
    {
        private readonly IHttpService _httpService;
        private readonly string baseURL = "api/product";

        public ProductClient(IHttpService httpService)
        {
            this._httpService = httpService;
        }

        public async Task<int> Create(CreateProductDTO newProduct)
        {
            var response = await _httpService.Post<CreateProductDTO, int>(baseURL, newProduct);

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

        public async Task<List<ProductViewModel>> GetAllByCategory(int id)
        {
            var response = await _httpService.Get<List<ProductViewModel>>($"{baseURL}/bycategory/{id}");

            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }

            return response.Data;
        }

        public Task Update(CreateProductDTO newProduct)
        {
            throw new NotImplementedException();
        }
    }
}
