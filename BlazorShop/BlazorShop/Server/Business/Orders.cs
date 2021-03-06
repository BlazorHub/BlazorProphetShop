﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorShop.Client.Store;
using BlazorShop.Shared.Models;

namespace BlazorShop.Server.Business
{
    class Orders 
    {
        public static double CalculateDiscountValue(Order order) 
        {
            double adjustment = Math.Pow(10, 1);
            double value = (CalculateProductsValue(order) + CalculateShippingValue(order)) * order.DiscountPercentage / 100;

            return Math.Floor(value * adjustment) / adjustment;
        }

        public static double CalculateProductsValue(Order order) 
        {
            double adjustment = Math.Pow(10, 1);
            double value = order.OrderProduct.Aggregate(0.00, (sum, cartProduct) => sum + (cartProduct.Value * cartProduct.Quantity));

            return Math.Floor(value * adjustment) / adjustment;
        }

        public static double CalculateShippingValue(Order order) 
        {
            double valuePerProduct = 1.50;

            double adjustment = Math.Pow(10, 1);
            double value = order.OrderProduct.Aggregate(0.00, (sum, cartProduct) => sum + (cartProduct.Quantity * valuePerProduct));

            return Math.Floor(value * adjustment) / adjustment;
        }

        public static double CalculateGrandTotal(Order order)
        {
            return CalculateShippingValue(order) + CalculateProductsValue(order) - CalculateDiscountValue(order);
        }
    }
}
