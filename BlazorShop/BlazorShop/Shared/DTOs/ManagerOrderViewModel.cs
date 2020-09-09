using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorShop.Shared.DTOs
{
    public class ManagerOrderViewModel
    {
        public int Id { get; set; }
        public string Payment { get; set; }
        public string Status { get; set; }
        public string CustomerName { get; set; }
        public DateTime CreatedAt { get; set; }
        public double Total { get; set; }
        public double ShippingValue { get; set; }
        public double DiscountValue { get; set; }
        public double ProductsValue { get; set; }
        public List<OrderProductViewModel> OrderProduct { get; set; }
    }
}
