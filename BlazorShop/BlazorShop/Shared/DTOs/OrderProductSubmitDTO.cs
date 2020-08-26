using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorShop.Shared.DTOs
{
    public class OrderProductSubmitDTO
    {
        public int Quantity { get; set; }
        public double Value { get; set; }
        public int ProductId { get; set; }
    }
}
