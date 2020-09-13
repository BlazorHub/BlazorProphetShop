using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorShop.Shared.DTOs.User;
using BlazorShop.Shared.Http;

namespace BlazorShop.Client.Data.Users
{
    interface IUserClient
    {
        Task<HttpResponse<UserToken>> Login(UserLoginDTO userInfo);
        Task<HttpResponse<int>> Register(CreateUserDTO userInfo);
        Task Update(UpdateUserDTO userInfo, int id);
        Task<UpdateUserDTO> GetSingle(int id);
        Task<List<GetUserDTO>> GetAllCustomers();
        Task UpdateUserEnabled(UpdateUserStatusDTO updatedStatus, int id);
    }
}
