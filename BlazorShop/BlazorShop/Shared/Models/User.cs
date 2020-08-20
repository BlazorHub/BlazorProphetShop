using System;
using System.Collections.Generic;

namespace BlazorShop.Shared.Models
{
    public partial class User
    {
        public User()
        {
            Order = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public bool Enabled { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Document { get; set; }
        public string Discriminator { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public virtual Address Address { get; set; }
        public virtual ICollection<Order> Order { get; set; }
    }
}
