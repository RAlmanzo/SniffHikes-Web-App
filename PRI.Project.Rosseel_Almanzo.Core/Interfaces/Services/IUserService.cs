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
        Task<ResultModel<User>> GetByIdAsync(int id);
        Task<ResultModel<User>> CreateUserAsync(UserCreateRequestModel UserCreateRequestModel);
        Task<ResultModel<User>> UpdateUserAsync(UserUpdateRequestModel UserUpdateRequestModel);
        Task<ResultModel<User>> DeleteUserAsync(int id);
        Task<bool> CheckIfExistsAsync(int id);
        //Task<bool> AddDogToUser(int id);
        //Task<bool> DeleteDogFromUser(int userId, int dogId)
    }
}
