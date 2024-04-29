using Microsoft.AspNetCore.Identity;
using PRI.Project.Rosseel_Almanzo.Core.Entities;
using PRI.Project.Rosseel_Almanzo.Core.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRI.Project.Rosseel_Almanzo.Core.Interfaces.Services
{
    public interface IUserService
    {
        Task<ResultModel<IEnumerable<User>>> GetAllAsync();
        Task<ResultModel<User>> GetByIdAsync(string id);
        Task<ResultModel<User>> CreateUserAsync(UserCreateRequestModel UserCreateRequestModel);
        Task<ResultModel<User>> UpdateUserAsync(UserUpdateRequestModel UserUpdateRequestModel);
        Task<ResultModel<User>> DeleteUserAsync(string id);
        Task<bool> CheckIfExistsAsync(string id);
        Task<ResultModel<IEnumerable<User>>> SearchByFirstNameAsync(string firstName);
        Task<ResultModel<IEnumerable<User>>> SearchByLastNameAsync(string lastName);
        Task<ResultModel<string>> LoginUserAsync(string userName, string password);
        Task<bool> SignOutUserAsync();
    }
}
