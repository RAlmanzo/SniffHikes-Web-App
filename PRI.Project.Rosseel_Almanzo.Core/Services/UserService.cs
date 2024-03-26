using PRI.Project.Rosseel_Almanzo.Core.Entities;
using PRI.Project.Rosseel_Almanzo.Core.Interfaces.Repositories;
using PRI.Project.Rosseel_Almanzo.Core.Interfaces.Services;
using PRI.Project.Rosseel_Almanzo.Core.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRI.Project.Rosseel_Almanzo.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<ResultModel<User>> DeleteUserAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResultModel<IEnumerable<User>>> GetAllAsync()
        {
            //get the users
            var users = await _userRepository.GetAllAsync();
            //create new resultmodel
            var userResultModel = new ResultModel<IEnumerable<User>>();
            //check if count > 0
            if (users.Count() > 0)
            {
                userResultModel.Success = true;
                userResultModel.Value = users;
                return userResultModel;
            }
            //if not
            userResultModel.Errors = new List<string> { "No uers found" };
            return userResultModel;
        }

        public Task<ResultModel<User>> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
