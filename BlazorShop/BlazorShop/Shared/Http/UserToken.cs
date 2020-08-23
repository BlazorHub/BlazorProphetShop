using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorShop.Shared.Http
{
    public class UserToken
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
