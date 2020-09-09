using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorShop.Shared.DTOs
{
    public class ManagerOrderItemViewModel
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public double Total { get; set; }
    }
}
