using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorShop.Shared.DTOs.Order
{
    public class OrderProductSubmitDTO
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Value { get; set; }
        public int ProductId { get; set; }
        public string ImageName { get; set; }
    }
}
