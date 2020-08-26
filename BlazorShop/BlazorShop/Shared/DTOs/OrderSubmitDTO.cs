using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorShop.Shared.DTOs
{
    public class OrderSubmitDTO
    {
        public OrderSubmitDTO()
        {
            OrderProduct = new List<OrderProductSubmitDTO>();
        }
        public int CustomerId { get; set; }
        public string Payment { get; set; }
        public int DiscountPercentage { get; set; }
        public virtual ICollection<OrderProductSubmitDTO> OrderProduct { get; set; }
    }
}
