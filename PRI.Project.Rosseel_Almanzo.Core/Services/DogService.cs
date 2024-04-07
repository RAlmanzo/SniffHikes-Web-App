using PRI.Project.Rosseel_Almanzo.Core.Entities;
using PRI.Project.Rosseel_Almanzo.Core.Interfaces.Repositories;
using PRI.Project.Rosseel_Almanzo.Core.Interfaces.Services;
using PRI.Project.Rosseel_Almanzo.Core.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PRI.Project.Rosseel_Almanzo.Core.Services
{
    public class DogService : IDogService
    {
        private readonly IDogRepository _dogRepository;
        private readonly IUserRepository _userRepository;
        private readonly IEventRepository _eventRepository;

        public DogService(IDogRepository repository, IUserRepository userRepository, IEventRepository eventRepository)
        {
            _dogRepository = repository;
            _userRepository = userRepository;
            _eventRepository = eventRepository;
        }

        public async Task<ResultModel<User>> AddDogAsync(DogCreateRequestModel dogCreateRequestModel)
        {
            //check if user exists
            if (_userRepository.GetAll().Any(g => g.Id == dogCreateRequestModel.UserId) == false)
            {
                return new ResultModel<User>
                {
                    Success = false,
                    Errors = new List<string> { "User does not exist!" }
                };
            }

            //create new dog
            var newDog = new Dog
            {
                Name = dogCreateRequestModel.Name,
                Race = dogCreateRequestModel.Race,
                Gender = dogCreateRequestModel.Gender,
                DateOfBirth = dogCreateRequestModel.DateOfBirth,
                Image = dogCreateRequestModel.Image,
                UserId = dogCreateRequestModel.UserId,
            };

            //call the usersrepo addAsync method
            var result = false;
            if(await _dogRepository.AddAsync(newDog))
            {
                //get updateUser
                var updatedUser = await _userRepository.GetByIdAsync(dogCreateRequestModel.UserId);
                foreach (var attendingEvent in updatedUser.AttendingEvents)
                {
                    var attendingEventResult = await _eventRepository.GetByIdAsync((int)attendingEvent.EventId);
                    attendingEvent.Event = attendingEventResult;
                }
                result = true;
            }

            //check  result
            if (result)
            {
                var updatedUser = await _userRepository.GetByIdAsync(newDog.UserId);

                return new ResultModel<User>
                {
                    Success = true,
                    Value = updatedUser,
                };
            }
            return new ResultModel<User>
            {
                Success = false,
                Errors = new List<string> { "Dog not created!" }
            };
        }

        public async Task<ResultModel<Dog>> DeleteDogAsync(int dogId)
        {
            //get the dog
            var dog = await _dogRepository.GetByIdAsync(dogId);

            //check if dog exists
            if (dog == null)
            {
                return new ResultModel<Dog>
                {
                    Success = false,
                    Errors = new List<string> { "User does not exist!" }
                };
            }

            //check if deleteAsync returns true
            if (await _dogRepository.DeleteAsync(dog))
            {
                return new ResultModel<Dog> { Success = true, };
            }

            //if not
            return new ResultModel<Dog>
            {
                Success = false,
                Errors = new List<string> { "Some error occured!" }
            };
        }

        public async Task<ResultModel<Dog>> GetByIdAsync(int id)
        {
            //get the user
            var dog = await _dogRepository.GetByIdAsync(id);
            //create new resultmodel
            var dogResultModel = new ResultModel<Dog>();
            //check if exists
            if (dog == null)
            {
                dogResultModel.Success = false;
                dogResultModel.Errors = new List<string> { "User not found" };
                return dogResultModel;
            }

            //if yes
            dogResultModel.Success = true;
            dogResultModel.Value = dog;
            return dogResultModel;
        }

        public async Task<ResultModel<Dog>> UpdateDogAsync(DogUpdateRequestModel dogUpdateRequestModel)
        {
            //check if user exists
            if (_userRepository.GetAll().Any(g => g.Id == dogUpdateRequestModel.UserId) == false)
            {
                return new ResultModel<Dog>
                {
                    Success = false,
                    Errors = new List<string> { "User does not exist!" }
                };
            }

            //check if userdog exists
            if (_userRepository.GetAllUserDogs(dogUpdateRequestModel.UserId).Any(d => d.Id == dogUpdateRequestModel.Id) == false)
            {
                return new ResultModel<Dog>
                {
                    Success = false,
                    Errors = new List<string> { "User does not own this dog" }
                };
            }
            //get the dog
            var dog = await _dogRepository.GetByIdAsync(dogUpdateRequestModel.Id);
            //update
            dog.Id = dogUpdateRequestModel.Id;
            dog.Name = dogUpdateRequestModel.Name;
            dog.Race = dogUpdateRequestModel.Race;
            dog.Gender = dogUpdateRequestModel.Gender;
            dog.DateOfBirth = dogUpdateRequestModel.DateOfBirth;
            dog.UserId = dogUpdateRequestModel.UserId;

            if (!string.IsNullOrWhiteSpace(dogUpdateRequestModel.Image))
            {
                dog.Image = dogUpdateRequestModel.Image;
            }

            if (await _dogRepository.UpdateAsync(dog))
            {
                return new ResultModel<Dog>
                {
                    Success = true,
                    Value = dog,
                };
            }
            return new ResultModel<Dog>
            {
                Success = false,
                Errors = new List<string> { "Dog update failed!" }
            };
        }

        public async Task<bool> CheckIfExistsAsync(int id)
        {
            return await _userRepository.CheckIfExistsAsync(id);
        }
    }
}
