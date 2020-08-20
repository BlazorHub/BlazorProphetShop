using System;
using System.Collections.Generic;

namespace BlazorShop.Shared.Models
{
    public partial class OrderProduct
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public double Value { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
