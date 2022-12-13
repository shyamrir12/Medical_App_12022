


using Medical_App_1.Shared.Models.UserModels;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Medical_App_1.Server.Services.UserManage.Interfaces
{
    public interface IUserService
    {
        Task<User> Authenticate(string username, string password);
        Task<List<User>> GetAll();
        Task<User> GetUserById(string UserId);

    }
}
