using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorShop.Shared.DTOs.User
{
    public class UpdateUserDTO
    {
        public UpdateUserDTO()
        {
            Address = new CreateUserAddressDTO();
        }

        public string Password { get; set; }
        public string Name { get; set; }
        public string Email { get; set; } 
        public string Phone { get; set; }
        public string Document { get; set; }
        public CreateUserAddressDTO Address { get; set; }
    }
}
