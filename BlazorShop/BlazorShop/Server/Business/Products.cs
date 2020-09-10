using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorShop.Shared.DTOs;
using BlazorShop.Shared.Models;
using BlazorShop.Shared.ViewModels;

namespace BlazorShop.Server.Business 
{
    class Products 
    {
        public static double CalculatePromotionValue(ProductViewModel product) 
        {
            double adjustment = Math.Pow(10, 1);
            double value = product.Value - (product.Value * product.PromotionPercentage / 100);

            return Math.Floor(value * adjustment) / adjustment;
        }
    }
}
