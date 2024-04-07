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
        private readonly IAddressRepository _addressRepository;
        private readonly IEventUserRepository _eventUserRepository;
        private readonly IEventRepository _eventRepository;
        private readonly IDogRepository _dogRepository;

        public UserService(IUserRepository userRepository, IAddressRepository addressRepository, IEventUserRepository eventUserRepository, IEventRepository eventRepository, IDogRepository dogRepository)
        {
            _userRepository = userRepository;
            _addressRepository = addressRepository;
            _eventUserRepository = eventUserRepository;
            _eventRepository = eventRepository;
            _dogRepository = dogRepository;
        }

        public async Task<ResultModel<User>> CreateUserAsync(UserCreateRequestModel userCreateRequestModel)
        {
            //check if user excist
            var users = await _userRepository.GetAllAsync();            
            if(users.Any(u => u.Email.ToUpper().Equals(userCreateRequestModel.Email.ToUpper())))
            {
                return new ResultModel<User>
                {
                    Success = false,
                    Errors = new List<string> { "User allready exists!" }
                };
            }

            //create new user
            var newUser = new User
            {
                FirstName = userCreateRequestModel.FirstName,
                LastName = userCreateRequestModel.LastName,
                DateOfBirth = userCreateRequestModel.DateOfBirth,
                Gender = userCreateRequestModel.Gender,
                Email = userCreateRequestModel.Email,
                Password = userCreateRequestModel.Password,
                Image = userCreateRequestModel.Image,
                Address = new Address
                {
                    Street = userCreateRequestModel.Address.Street,
                    City = userCreateRequestModel.Address.City,
                    State = userCreateRequestModel.Address.State,
                    Country = userCreateRequestModel.Address.Country,
                },
            };

            //call the usersrepo addAsync method
            var result = await _userRepository.AddAsync(newUser);        
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
                Errors = new List<string> { "User not created!" }
            };
        }

        public async Task<ResultModel<User>> DeleteUserAsync(int id)
        {
            //get the user
            var selectedUser = await _userRepository.GetByIdAsync(id);
            //get user address
            var userAddress = await _addressRepository.GetByIdAsync(selectedUser.AddressId);

            //check iff user exists
            if (selectedUser == null)
            {
                return new ResultModel<User>
                {
                    Success = false,
                    Errors = new List<string> { "User does not exist!" }
                };
            }

            // get all EventUser records associated with the user
            var userEventUsers = await _eventUserRepository.GetAllByUserId(id);

            // delete all EventUser records associated with the user
            foreach (var eventUser in userEventUsers)
            {
                await _eventUserRepository.DeleteAsync(eventUser);
            }

            //check if deleteAsync returns true
            if (await _userRepository.DeleteAsync(selectedUser))
            {
                if (await _addressRepository.DeleteAsync(userAddress))
                {
                    return new ResultModel<User> { Success = true, };
                }             
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
                userResultModel.Errors = new List<string> { "User not found" };
                return userResultModel;
            }

            foreach (var attendingEvent in user.AttendingEvents) 
            {
                var result = await _eventRepository.GetByIdAsync((int)attendingEvent.EventId);
                attendingEvent.Event = result;
            }

            //if yes
            userResultModel.Success = true;
            userResultModel.Value = user;
            return userResultModel;
        }

        public async Task<ResultModel<User>> UpdateUserAsync(UserUpdateRequestModel userUpdateRequestModel)
        {
            //get the user
            var user = await _userRepository.GetByIdAsync(userUpdateRequestModel.Id);

            //update
            user.Id = userUpdateRequestModel.Id;
            user.FirstName = userUpdateRequestModel.FirstName;
            user.LastName = userUpdateRequestModel.LastName;
            user.Email = userUpdateRequestModel.Email;
            user.Gender = userUpdateRequestModel.Gender;
            user.Password = userUpdateRequestModel.Password;
            user.Address.Street = userUpdateRequestModel.Address.Street;
            user.Address.City = userUpdateRequestModel.Address.City;
            user.Address.State = userUpdateRequestModel.Address.State;
            user.Address.Country = userUpdateRequestModel.Address.Country;
            user.DateOfBirth = userUpdateRequestModel.DateOfBirth;
            

            if (!string.IsNullOrWhiteSpace(userUpdateRequestModel.Image))
            {
                user.Image = userUpdateRequestModel.Image;
            }

            if (await _userRepository.UpdateAsync(user))
            {
                return new ResultModel<User>
                {
                    Success = true,
                    Value = user,
                };
            }
            return new ResultModel<User>
            {
                Success = false,
                Errors = new List<string> { "Record update failed!" }
            };
        }

        public async Task<bool> CheckIfExistsAsync(int id)
        {
            return await _userRepository.CheckIfExistsAsync(id);
        }
    }
}
