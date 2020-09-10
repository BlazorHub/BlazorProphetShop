using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorShop.Shared.DTOs.Product
{
    public class CreateProductDTO
    {
        public string CategoryName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Value { get; set; }
        public bool Promotion { get; set; } = true;
        public int PromotionPercentage { get; set; }
        public int Quantity { get; set; }
        public byte[] ImageContent { get; set; }
    }
}
