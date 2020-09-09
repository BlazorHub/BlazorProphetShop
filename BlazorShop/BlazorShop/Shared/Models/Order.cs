using System;
using System.Collections.Generic;

namespace BlazorShop.Shared.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderProduct = new HashSet<OrderProduct>();
        }

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Payment { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int DiscountPercentage { get; set; }
        public virtual User Customer { get; set; }
        public virtual ICollection<OrderProduct> OrderProduct { get; set; }
    }
}
