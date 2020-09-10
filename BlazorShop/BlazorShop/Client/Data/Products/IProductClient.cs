using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorShop.Shared.DTOs.Product;
using BlazorShop.Shared.Models;
using BlazorShop.Shared.ViewModels;

namespace BlazorShop.Client.Data.Products
{
    public interface IProductClient
    {
        Task<List<ProductViewModel>> GetAll();
        Task<List<ProductViewModel>> GetAllByCategory(int id);
        Task<int> Create(CreateProductDTO newProduct);
        Task Update(CreateProductDTO newProduct);
        Task Delete(int productId);
    }
}
