using Microsoft.AspNetCore.Identity;
using PRI.Project.Rosseel_Almanzo.Core.Entities;
using PRI.Project.Rosseel_Almanzo.Core.Interfaces.Repositories;
using PRI.Project.Rosseel_Almanzo.Core.Interfaces.Services;
using PRI.Project.Rosseel_Almanzo.Core.Services.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PRI.Project.Rosseel_Almanzo.Core.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;
        private readonly IUserRepository _userRepository;
        private readonly IEventUserRepository _eventUserRepository;
        private readonly IImageRepository _imageRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly ICommentRepository _commentRepository;
        private readonly UserManager<User> _userManager;

        public EventService(IEventRepository eventRepository, IUserRepository userRepository, IEventUserRepository eventUserRepository, IAddressRepository addressRepository, IImageRepository imageRepository, ICommentRepository commentRepository, UserManager<User> userManager)
        {
            _eventRepository = eventRepository;
            _userRepository = userRepository;
            _eventUserRepository = eventUserRepository;
            _addressRepository = addressRepository;
            _imageRepository = imageRepository;
            _commentRepository = commentRepository;
            _userManager = userManager;
        }

        public async Task<ResultModel<Event>> CreateEventAsync(EventCreateRequestModel eventCreateRequestModel)
        {
            //get the orginazer
            var orginazer = await _userRepository.GetByIdAsync(eventCreateRequestModel.OrganizerId);
            if (orginazer == null)
            {
                return new ResultModel<Event>
                {
                    Success = false,
                    Errors = new List<string> { "Orginazer does not exist!" }
                };
            }

            //get the claims
            var claims = await _userManager.GetClaimsAsync(orginazer);
            if(!claims.Any(c => c.Value == "Orginazer"))
            {
                //create new claim for user
                var orginazerClaim = new Claim
                (
                    ClaimTypes.Role,
                    "Orginazer"
                );

                var claimResult = await _userManager.AddClaimAsync(orginazer, orginazerClaim);
                if (!claimResult.Succeeded)
                {
                    return new ResultModel<Event>
                    {
                        Success = false,
                        Errors = new List<string> { "Failed: could not add claim, please contact admin" }
                    };
                }
            }

            //fill imageslist with added image
            var imageList = new List<Image>();
            if (eventCreateRequestModel.Images.Count() > 0)
            {
                foreach(var image in  eventCreateRequestModel.Images)
                {
                    var currentImage = new Image { File = image };
                    imageList.Add(currentImage);
                };
            }
                    
            //create new event
            var newEvent = new Event
            {
                Title = eventCreateRequestModel.Title,
                Description = eventCreateRequestModel.Description,
                Price = eventCreateRequestModel.Price,
                DateCreated = DateTime.Now,
                Address = new Address
                {
                    Street = eventCreateRequestModel.Street,
                    City = eventCreateRequestModel.City,
                    State = eventCreateRequestModel.State,
                    Country = eventCreateRequestModel.Country,
                },
                Date = eventCreateRequestModel.Date,
                OrganizerId = eventCreateRequestModel.OrganizerId,
                Images = imageList,
            };

            //call the eventsrepo addAsync method for the event
            var result = await _eventRepository.AddAsync(newEvent);           
            if (result)
            {
                var createdRecord = await GetByIdAsync(newEvent.Id);
                return new ResultModel<Event>
                {
                    Success = true,
                    Value = createdRecord.Value,
                };
            }
            return new ResultModel<Event>
            {
                Success = false,
                Errors = new List<string> { "Event not created!" }
            };
        }

        public async Task<ResultModel<Event>> DeleteEventAsync(int id)
        {
            //get the event
            var selectedEvent = await _eventRepository.GetByIdAsync(id);
            //check if event exists
            if (selectedEvent == null)
            {
                return new ResultModel<Event>
                {
                    Success = false,
                    Errors = new List<string> { "Event does not exist!" }
                };
            }

            //get event address
            var eventAddress = await _addressRepository.GetByIdAsync(selectedEvent.AddressId);
            //get route comments
            var eventComments = _eventRepository.GetAllEventComments(selectedEvent.Id);
            //get route images
            var eventImages = _eventRepository.GetAllEventImages(selectedEvent.Id);
            // get all EventUser records associated with the event
            var eventUsers = await _eventUserRepository.GetAllByEventId(id);

            // delete all EventUser records associated with the user before deleting event
            foreach (var eventUser in eventUsers)
            {
                await _eventUserRepository.DeleteAsync(eventUser);
            }

            //check if deleteAsync returns true
            if (await _eventRepository.DeleteAsync(selectedEvent))
            {
                if (await _addressRepository.DeleteAsync(eventAddress))
                {
                    foreach (var image in eventImages)
                    {
                        await _imageRepository.DeleteAsync(image);
                    }
                    foreach (var comment in eventComments)
                    {
                        await _commentRepository.DeleteAsync(comment);
                    }
                    return new ResultModel<Event> { Success = true, };
                }
            }

            //if not
            return new ResultModel<Event>
            {
                Success = false,
                Errors = new List<string> { "Some error occured!" }
            };
        }

        public async Task<ResultModel<IEnumerable<Event>>> GetAllAsync()
        {
            //get the events
            var events = await _eventRepository.GetAllAsync();
            //create new resultmodel
            var eventResultModel = new ResultModel<IEnumerable<Event>>();
            //check if count > 0
            if (events.Count() > 0)
            {
                eventResultModel.Success = true;
                eventResultModel.Value = events;
                return eventResultModel;
            }
            //if not
            eventResultModel.Errors = new List<string> {"No events found"};
            return eventResultModel;
        }

        public async Task<ResultModel<Event>> GetByIdAsync(int id)
        {
            //get the event
            var selectedEvent = await _eventRepository.GetByIdAsync(id);
            //create new resultmodel
            var eventResultModel = new ResultModel<Event>();
            //check if exists
            if (selectedEvent == null)
            {
                eventResultModel.Success = false;
                eventResultModel.Errors = new List<string> { "No event found" };
                return eventResultModel;
            }
            //get event attendingusers
            foreach (var attendingUser in selectedEvent.AttendingUsers)
            {
                var result = await _userRepository.GetByIdAsync(attendingUser.UserId);
                attendingUser.User = result;
            }
            //if event exists
            eventResultModel.Success = true;
            eventResultModel.Value = selectedEvent;
            return eventResultModel;
        }

        public async Task<bool> CheckIfExistsAsync(int id)
        {
            return await _eventRepository.CheckIfExistsAsync(id);
        }

        public async Task<ResultModel<Event>> UpdateEventAsync(EventUpdateRequestModel eventUpdateRequestModel)
        {
            //check if organizerid exists
            if (_userRepository.GetAll().Any(g => g.Id == eventUpdateRequestModel.OrganizerId) == false)
            {
                return new ResultModel<Event>
                {
                    Success = false,
                    Errors = new List<string> { "Orginazer does not exist!" }
                };
            }

            //get the event
            var selectedEvent = await _eventRepository.GetByIdAsync(eventUpdateRequestModel.Id);
            
            //update event
            selectedEvent.Id = eventUpdateRequestModel.Id;
            selectedEvent.Title = eventUpdateRequestModel.Title;
            selectedEvent.Description = eventUpdateRequestModel.Description;
            selectedEvent.Price = eventUpdateRequestModel.Price;
            selectedEvent.Address.Street = eventUpdateRequestModel.Street;
            selectedEvent.Address.City = eventUpdateRequestModel.City;
            selectedEvent.Address.State = eventUpdateRequestModel.State;
            selectedEvent.Address.Country = eventUpdateRequestModel.Country;
            selectedEvent.OrganizerId = eventUpdateRequestModel.OrganizerId;
            selectedEvent.Date = eventUpdateRequestModel.Date;
            selectedEvent.DateCreated = eventUpdateRequestModel.DateCreated;       

            if (await _eventRepository.UpdateAsync(selectedEvent))
            {
                return new ResultModel<Event>
                {
                    Success = true,
                    Value = selectedEvent,
                };
            }
            return new ResultModel<Event>
            {
                Success = false,
                Errors = new List<string> { "Event update failed!" }
            };
        }

        public async Task<ResultModel<Event>> AddImageAsync(int id, string imagePath)
        {
            //check if event exists
            if (_eventRepository.GetAll().Any(g => g.Id == id) == false)
            {
                return new ResultModel<Event>
                {
                    Success = false,
                    Errors = new List<string> { "Event does not exist!" }
                };
            }

            //check if image is present
            var result = false;
            if (!string.IsNullOrWhiteSpace(imagePath))
            {
                var image = new Image { File = imagePath, EventId = id };
                result = await _imageRepository.AddAsync(image);
            }

            if (result)
            {
                var updatedEvent = await GetByIdAsync(id);
                return new ResultModel<Event>
                {
                    Success = true,
                    Value = updatedEvent.Value,
                };
            }
            return new ResultModel<Event>
            {
                Success = false,
                Errors = new List<string> { "Event not created!" }
            };
        }

        public async Task<ResultModel<IEnumerable<Event>>> SearchByTitleAsync(string title)
        {
            var events = await _eventRepository.GetAllAsync();

            var selectedEvent =  events.Where(r => r.Title.ToUpper().Contains(title.ToUpper())).ToList();
            if (selectedEvent.Count() > 0)
            {
                return new ResultModel<IEnumerable<Event>>
                {
                    Value = selectedEvent,
                    Success = true
                };
            }

            return new ResultModel<IEnumerable<Event>>
            {
                Success = false,
                Errors = new List<string> { "No events found" }
            };
        }
    }
}
