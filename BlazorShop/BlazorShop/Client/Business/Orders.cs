using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorShop.Client.Store;
using BlazorShop.Shared.Models;

namespace BlazorShop.Client 
{
    class Orders 
    {
        public static double CalculateDiscountValue(OrderState order) 
        {
            double adjustment = Math.Pow(10, 1);
            double value = (CalculateProductsValue(order) + CalculateShippingValue(order)) * order.DiscountPercentage / 100;

            return Math.Floor(value * adjustment) / adjustment;
        }

        public static double CalculateProductsValue(OrderState order) 
        {
            double adjustment = Math.Pow(10, 1);
            double value = order.OrderProduct.Aggregate(0.00, (sum, cartProduct) => sum + (cartProduct.Value * cartProduct.Quantity));

            return Math.Floor(value * adjustment) / adjustment;
        }

        public static double CalculateShippingValue(OrderState order) 
        {
            double valuePerProduct = 1.50;

            double adjustment = Math.Pow(10, 1);
            double value = order.OrderProduct.Aggregate(0.00, (sum, cartProduct) => sum + (cartProduct.Quantity * valuePerProduct));

            return Math.Floor(value * adjustment) / adjustment;
        }
    }
}
