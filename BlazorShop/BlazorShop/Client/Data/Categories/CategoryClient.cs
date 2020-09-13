using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorShop.Client.Helpers;
using BlazorShop.Shared.DTOs.Category;

namespace BlazorShop.Client.Data.Categories
{
    public class CategoryClient : ICategoryClient
    {
        private readonly IHttpService _httpService;
        private readonly string baseURL = "api/category";

        public CategoryClient(IHttpService httpService)
        {
            this._httpService = httpService;
        }
        public async Task<List<GetCategoryDTO>> GetAll()
        {
            var response = await _httpService.Get<List<GetCategoryDTO>>(baseURL);

            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }

            return response.Data;
        }
    }
}
