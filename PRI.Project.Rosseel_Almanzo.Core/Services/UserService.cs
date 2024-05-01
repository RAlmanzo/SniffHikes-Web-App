using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PRI.Project.Rosseel_Almanzo.Core.Entities;
using PRI.Project.Rosseel_Almanzo.Core.Interfaces.Repositories;
using PRI.Project.Rosseel_Almanzo.Core.Interfaces.Services;
using PRI.Project.Rosseel_Almanzo.Core.Services.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
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
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _configuration;

        public UserService(IUserRepository userRepository, IAddressRepository addressRepository, IEventUserRepository eventUserRepository, IEventRepository eventRepository, IDogRepository dogRepository, UserManager<User> userManager, SignInManager<User> signInManager, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _addressRepository = addressRepository;
            _eventUserRepository = eventUserRepository;
            _eventRepository = eventRepository;
            _dogRepository = dogRepository;
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        public async Task<ResultModel<User>> CreateUserAsync(UserCreateRequestModel userCreateRequestModel)
        {
            //check if email allready excist
            var userResult = await _userManager.FindByEmailAsync(userCreateRequestModel.Email);
            if(userResult != null)
            {
                return new ResultModel<User>
                {
                    Success = false,
                    Errors = new List<string> { "Email allready exists!" }
                };
            }

            //create new user
            var newUser = new User
            {
                UserName = userCreateRequestModel.Email,
                FirstName = userCreateRequestModel.FirstName,
                LastName = userCreateRequestModel.LastName,
                DateOfBirth = userCreateRequestModel.DateOfBirth,
                Gender = userCreateRequestModel.Gender,
                Email = userCreateRequestModel.Email,
                EmailConfirmed = true,//ONLY FOR TESTING/DEVELOPMENT PURPOSE
                Image = userCreateRequestModel.Image,
                Address = new Address
                {
                    Street = userCreateRequestModel.Address.Street,
                    City = userCreateRequestModel.Address.City,
                    State = userCreateRequestModel.Address.State,
                    Country = userCreateRequestModel.Address.Country,
                },
                Password = userCreateRequestModel.Password,             
            };

            //call the usersrepo addAsync method
            var result = await _userRepository.AddAsync(newUser);
            //check  result
            if (!result.Succeeded)
            {
                return new ResultModel<User>
                {
                    Success = false,
                    Errors = new List<string> { "Registration failed!" }
                };
            }

            //add the claims
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Role,"User"),
                new Claim(ClaimTypes.DateOfBirth,newUser.DateOfBirth.ToString()),
                new Claim(ClaimTypes.Name,newUser.UserName),
                new Claim(ClaimTypes.NameIdentifier,newUser.Id),
            };
            //add claims to user
            result = await _userManager.AddClaimsAsync(newUser, claims);
            if (!result.Succeeded)
            {
                return new ResultModel<User>
                {
                    Success = false,
                    Errors = new List<string> { "User not created!" }
                };
            }

            var createdRecord = await GetByIdAsync(newUser.Id);
            return new ResultModel<User>
            {
                Success = true,
                Value = createdRecord.Value,
            };
        }

        public async Task<ResultModel<User>> DeleteUserAsync(string id)
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
            var result = await _userRepository.DeleteAsync(selectedUser);
            if (result.Succeeded)
            {
                if (await _addressRepository.DeleteAsync(userAddress))
                {
                    if (selectedUser.Dogs.Count > 0)
                    {
                        foreach (var dog in selectedUser.Dogs)
                        {
                            await _dogRepository.DeleteAsync(dog);
                        }
                    }
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

        public async Task<ResultModel<User>> GetByIdAsync(string id)
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
            //user.Password = userUpdateRequestModel.Password;
            user.Address.Street = userUpdateRequestModel.Address.Street;
            user.Address.City = userUpdateRequestModel.Address.City;
            user.Address.State = userUpdateRequestModel.Address.State;
            user.Address.Country = userUpdateRequestModel.Address.Country;
            user.DateOfBirth = userUpdateRequestModel.DateOfBirth;
            
            if (user.Password != userUpdateRequestModel.Password)
            {
                var resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
                await _userManager.ResetPasswordAsync(user, resetToken, userUpdateRequestModel.Password);
                //await _userManager.ChangePasswordAsync(user, user.Password, userUpdateRequestModel.Password);
                IPasswordHasher<User> passwordHasher = new PasswordHasher<User>();
                user.PasswordHash = passwordHasher.HashPassword(user, userUpdateRequestModel.Password);
                //user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, userUpdateRequestModel.Password);
                user.Password = userUpdateRequestModel.Password;
            }

            if (!string.IsNullOrWhiteSpace(userUpdateRequestModel.Image))
            {
                user.Image = userUpdateRequestModel.Image;
            }

            var result = await _userRepository.UpdateAsync(user);
            if (result)
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
                Errors = new List<string> { "User update failed!" }
            };
        }

        public async Task<bool> CheckIfExistsAsync(string id)
        {
            return await _userRepository.CheckIfExistsAsync(id);
        }

        public async Task<ResultModel<IEnumerable<User>>> SearchByFirstNameAsync(string firstName)
        {
            var users = await _userRepository.GetAllAsync();

            var selectedUsers = users.Where(r => r.FirstName.ToUpper().Contains(firstName.ToUpper())).ToList();
            if (selectedUsers.Count() > 0)
            {
                return new ResultModel<IEnumerable<User>>
                {
                    Value = selectedUsers,
                    Success = true
                };
            }

            return new ResultModel<IEnumerable<User>>
            {
                Success = false,
                Errors = new List<string> { "No users found" }
            };
        }

        public async Task<ResultModel<IEnumerable<User>>> SearchByLastNameAsync(string lastName)
        {
            var users = await _userRepository.GetAllAsync();

            var selectedUsers = users.Where(r => r.LastName.ToUpper().Contains(lastName.ToUpper())).ToList();
            if (selectedUsers.Count() > 0)
            {
                return new ResultModel<IEnumerable<User>>
                {
                    Value = selectedUsers,
                    Success = true
                };
            }

            return new ResultModel<IEnumerable<User>>
            {
                Success = false,
                Errors = new List<string> { "No users found" }
            };
        }

        public async Task<ResultModel<string>> LoginUserAsync(string email, string password)
        {
            //authenticate the user
            var result = await _signInManager.PasswordSignInAsync(email, password, false, false);
            if (!result.Succeeded)
            {
                return new ResultModel<string>
                {
                    Success = false,
                    Errors = new List<string> { "Wrong Credentials!" }
                };
            }
            //get the user
            var user = await _userManager.FindByEmailAsync(email);
            //get the claims
            var claims = await _userManager.GetClaimsAsync(user);
            //generate the token
            //set the token parameters
            var issuer = _configuration.GetValue<string>("JWTConfiguration:Issuer");
            var audience = _configuration.GetValue<string>("JWTConfiguration:Audience");
            var expiration = DateTime.Now.AddDays(_configuration.GetValue<int>("JWTConfiguration:ExpirationInDays"));
            var key = Encoding.UTF8.GetBytes(_configuration.GetValue<string>("JWTConfiguration:SecretKey"));
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(key);
            var signinCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            //token
            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                notBefore: DateTime.Now,
                expires: expiration,
                claims: claims,
                signingCredentials: signinCredentials
                );
            //serialize token
            var serializedToken = new JwtSecurityTokenHandler().WriteToken(token);
            //return the token
            return new ResultModel<string>
            {
                Success = true,
                Value = serializedToken,
            };
        }

        public async Task<bool> SignOutUserAsync()
        {
            await _signInManager.SignOutAsync();
            return true;
        }
    }
}
