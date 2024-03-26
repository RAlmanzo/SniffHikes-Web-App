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

        public async Task<ResultModel<User>> CreateUserAsync(UserCreateRequestModel userCreateRequestModel)
        {
            //create new user
            var newUser = new User
            {
                FirstName = userCreateRequestModel.FirstName,
                LastName = userCreateRequestModel.LastName,
                DateOfBirth = userCreateRequestModel.DateOfBirth,
                Gender = userCreateRequestModel.Gender,
                Email = userCreateRequestModel.Email,
                Password = userCreateRequestModel.Password,
                Address = new Address
                {
                    Street = userCreateRequestModel.Address.Street,
                    City = userCreateRequestModel.Address.City,
                    State = userCreateRequestModel.Address.State,
                    Country = userCreateRequestModel.Address.Country,
                },
            };
            //newUser.Dogs = userCreateRequestModel.Dogs.Select(d => new Dog
            //{
            //    Name = d.Name,
            //    Race = d.Race,
            //    Gender = d.Gender,
            //    DateOfBirth = d.DateOfBirth,
            //    Image = d.Image,
            //    UserId = newUser.Id,
            //}).ToList();

            //call the eventsrepo addAsync method for the event  and addres (images,...)
            var result = await _userRepository.AddAsync(newUser);
            //if (newEvent.Address == null)
            //{
            //    return new ResultModel<Event>
            //    {
            //        Success = false,
            //        Errors = new List<string> { "Address is null!" }
            //    };
            //}
            //var addressResult = await _addressRepository.AddAsync(newEvent.Address);
            //check  result
            if (result)
            {
                var createdRecord = await GetByIdAsync(newUser.Id);
                return new ResultModel<User>
                {
                    Success = true,
                    Value = createdRecord.Value,
                };
            }
            return new ResultModel<User>
            {
                Success = false,
                Errors = new List<string> { "Event not created!" }
            };
        }

        public async Task<ResultModel<User>> DeleteUserAsync(int id)
        {
            //get the user
            var selectedEvent = await _userRepository.GetByIdAsync(id);

            //check iff user exists
            if (selectedEvent == null)
            {
                return new ResultModel<User>
                {
                    Success = false,
                    Errors = new List<string> { "Event does not exist!" }
                };
            }

            //check if deleteAsync returns true
            if (await _userRepository.DeleteAsync(selectedEvent))
            {
                return new ResultModel<User> { Success = true, };
            }

            //if not
            return new ResultModel<User>
            {
                Success = false,
                Errors = new List<string> { "Some error occured!" }
            };
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

        public async Task<ResultModel<User>> GetByIdAsync(int id)
        {
            //get the user
            var user = await _userRepository.GetByIdAsync(id);
            //create new resultmodel
            var userResultModel = new ResultModel<User>();
            //check if exists
            if (user == null)
            {
                userResultModel.Success = false;
                userResultModel.Errors = new List<string> { "No event found" };
                return userResultModel;
            }
            //if yes
            userResultModel.Success = true;
            userResultModel.Value = user;
            return userResultModel;
        }

        public async Task<bool> CheckIfExistsAsync(int id)
        {
            return await _userRepository.CheckIfExistsAsync(id);
        }
    }
}
