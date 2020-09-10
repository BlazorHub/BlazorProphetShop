using BlazorShop.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorShop.Shared.DTOs.User
{
    public class CreateUserDTO
    {
        public CreateUserDTO()
        {
            Address = new CreateUserAddressDTO();
        }

        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Document { get; set; }
        public CreateUserAddressDTO Address { get; set; }
    }
}
