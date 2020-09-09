using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorShop.Shared.DTOs
{
    public class OrderProductViewModel
    {
        public string ProductName { get; set; }
        public double Value { get; set; }
        public int Quantity { get; set; }
        public string ImageName { get; set; }
    }
}
