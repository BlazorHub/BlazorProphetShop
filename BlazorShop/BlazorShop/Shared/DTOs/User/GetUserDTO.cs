using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorShop.Shared.DTOs.User
{
    public class GetUserDTO
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Phone { get; set; }
        public bool Enabled { get; set; }
    }
}
