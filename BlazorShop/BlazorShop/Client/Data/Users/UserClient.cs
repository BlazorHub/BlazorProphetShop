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
        private readonly string authUrl = "api/auth";
        private readonly string userUrl = "api/user";

        public UserClient(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<HttpResponse<int>> Register(CreateUserDTO userInfo)
        {
            var httpResponse = await _httpService.Post<CreateUserDTO, HttpResponse<int>>($"{authUrl}/register", userInfo);

            if (!httpResponse.Success)
            {
                throw new ApplicationException(await httpResponse.GetBody());
            }

            return httpResponse.Data;
        }

        public async Task<HttpResponse<UserToken>> Login(UserLoginDTO userInfo)
        {
            var httpResponse = await _httpService.Post<UserLoginDTO, HttpResponse<UserToken>>($"{authUrl}/login", userInfo);

            if (!httpResponse.Success)
            {
                throw new ApplicationException(await httpResponse.GetBody());
            }

            return httpResponse.Data;
        }

        public async Task Update(UpdateUserDTO userInfo, int id)
        {
            var httpResponse = await _httpService.Put<UpdateUserDTO>($"{userUrl}/{id}", userInfo);

            if (!httpResponse.Success)
            {
                throw new ApplicationException(await httpResponse.GetBody());
            }
        }

        public async Task<UpdateUserDTO> GetSingle(int id)
        {
            var response = await _httpService.Get<UpdateUserDTO>($"{userUrl}/{id}");

            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }

            return response.Data;
        }

        public async Task<List<GetUserDTO>> GetAllCustomers()
        {
            var response = await _httpService.Get<List<GetUserDTO>>(userUrl);

            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }

            return response.Data;
        }

        public async Task UpdateUserEnabled(UpdateUserStatusDTO updatedStatus, int id)
        {
            var response = await _httpService.Put<UpdateUserStatusDTO>($"{userUrl}/{id}/status", updatedStatus);

            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }
    }
}
