using BlazorShop.Shared.DTOs;
using BlazorShop.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorShop.Client.Repositories.Products
{
    public interface IProductRepository
    {
        Task<List<ProductViewModel>> GetProducts();
    }
}
