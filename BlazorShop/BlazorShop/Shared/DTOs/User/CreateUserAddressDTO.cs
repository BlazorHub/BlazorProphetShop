using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorShop.Shared.DTOs.User
{
    public class CreateUserAddressDTO
    {
        public string Name { get; set; } = "";
        public string City { get; set; } = "";
        public string State { get; set; } = "";
        public string ZipCode { get; set; } = "";
    }
}
