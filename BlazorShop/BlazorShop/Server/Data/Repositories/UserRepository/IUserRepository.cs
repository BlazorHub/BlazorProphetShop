using BlazorShop.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorShop.Server.Data.Repositories.UserRepository
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetSingleWithAddress(int id);
        Task<List<User>> GetAllCustomers();
    }
}
