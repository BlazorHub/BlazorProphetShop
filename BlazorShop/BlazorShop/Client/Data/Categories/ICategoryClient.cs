using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorShop.Shared.DTOs.Category;


namespace BlazorShop.Client.Data.Categories
{
    public interface ICategoryClient
    {
        Task<List<GetCategoryDTO>> GetAll();
    }
}
