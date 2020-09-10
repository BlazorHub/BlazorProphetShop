using BlazorShop.Client.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorShop.Shared.DTOs.User;
using BlazorShop.Shared.Http;

namespace BlazorShop.Client.Data.Users
{
    public class UserClient : IUserClient
    {
        private readonly IHttpService _httpService;
        private readonly string baseURL = "api/auth";

        public UserClient(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<HttpResponse<int>> Register(CreateUserDTO userInfo)
        {
            var httpResponse = await _httpService.Post<CreateUserDTO, HttpResponse<int>>($"{baseURL}/register", userInfo);

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
