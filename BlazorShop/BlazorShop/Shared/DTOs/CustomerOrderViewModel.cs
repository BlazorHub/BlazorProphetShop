using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorShop.Shared.DTOs
{
    public class CustomerOrderViewModel
    {
        public int Id { get; set; }
        public string Payment { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public double Total { get; set; }
        public List<OrderProductViewModel> OrderProduct { get; set; }
     }
}
