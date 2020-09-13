using BlazorShop.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorShop.Client.Helpers
{
    public class DisplayData
    {
        public static string FormatValue(double value)
        {
            return $"{value.ToString("0.##")} HRK";
        }

        public static string FormatQuantity(int value)
        {
            return $"{value}x";
        }

        public static string FormatID(int id)
        {
            return $"#{id}";
        }

        public static string FormatStyleOrderStatus(string status)
        {
            switch (status)
            {
                case OrderStatus.PENDING:
                    return "text-warning";
                case OrderStatus.CANCELED:
                    return "text-danger";
                case OrderStatus.APPROVED:
                    return "text-success";
                case OrderStatus.DELIVERED:
                    return "text-info";
                default:
                    return "text-info";
            }
        }

        public static string FormatUserStatus(bool status)
        {
            return status ? "Da" : "Ne";
        }

        public static string FormatStyleUserStatus(bool status)
        {
            return status ? "text-success" : "text-danger";
        }
    }
}
