using System;
using System.Collections.Generic;

namespace BlazorShop.Shared.Models
{
    public partial class Address
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        public virtual User Customer { get; set; }
    }
}
