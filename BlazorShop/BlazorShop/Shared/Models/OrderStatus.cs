using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorShop.Shared.Models
{
    public static class OrderStatus
    {
        public const string CANCELED = "Otkazano";
        public const string PENDING = "U tijeku";
        public const string APPROVED = "Odobreno";
        public const string DELIVERED = "Isporučeno";
    }
}
