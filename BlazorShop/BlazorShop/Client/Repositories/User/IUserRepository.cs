using BlazorShop.Shared.DTOs;
using BlazorShop.Shared.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorShop.Client.Repositories.User
{
    interface IUserRepository
    {
        Task<HttpResponse<UserToken>> Login(UserLoginDTO userInfo);
        Task<UserToken> Register(UserRegisterDTO userInfo);
    }
}
