using BlazorShop.Shared.DTOs;
using BlazorShop.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorShop.Client.Data.Products
{
    public interface IProductClient
    {
        Task<List<ProductViewModel>> GetAll();
        Task<List<ProductViewModel>> GetAllByCategory(int id);
        Task<int> Create(AddProductDTO newProduct);
        Task Update(AddProductDTO newProduct);
        Task Delete(int productId);
    }
}
