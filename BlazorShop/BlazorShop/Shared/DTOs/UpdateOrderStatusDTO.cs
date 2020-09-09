using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorShop.Shared.DTOs
{
    public class UpdateOrderStatusDTO
    {
        public int Id { get; set; }
        public string Status { get; set; }
    }
}
