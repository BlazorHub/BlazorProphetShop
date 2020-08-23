using BlazorShop.Client.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorShop.Shared.DTOs;
using BlazorShop.Shared.Http;

namespace BlazorShop.Client.Repositories.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly IHttpService _httpService;
        private readonly string baseURL = "api/auth";

        public UserRepository(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<UserToken> Register(UserRegisterDTO userInfo)
        {
            var httpResponse = await _httpService.Post<UserRegisterDTO, UserToken>($"{baseURL}/register", userInfo);

            if (!httpResponse.Success)
            {
                throw new ApplicationException(await httpResponse.GetBody());
            }

            return httpResponse.Data;
        }

        public async Task<HttpResponse<UserToken>> Login(UserLoginDTO userInfo)
        {
            var httpResponse = await _httpService.Post<UserLoginDTO, HttpResponse<UserToken>>($"{baseURL}/login", userInfo);

            if (!httpResponse.Success)
            {
                throw new ApplicationException(await httpResponse.GetBody());
            }

            return httpResponse.Data;
        }
    }
}
