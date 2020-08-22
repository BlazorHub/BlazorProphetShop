using BlazorShop.Shared.Http;
using BlazorShop.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorShop.Server.Services
{
    public interface IAuthenticationService
    {
        Task<HttpResponse<int>> Register(User user, string password);
        Task<HttpResponse<string>> Login(string username, string password);
        Task<bool> UserExists(string username);
    }
}
