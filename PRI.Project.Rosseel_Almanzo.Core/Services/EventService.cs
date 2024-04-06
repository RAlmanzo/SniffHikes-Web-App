using PRI.Project.Rosseel_Almanzo.Core.Entities;
using PRI.Project.Rosseel_Almanzo.Core.Interfaces.Repositories;
using PRI.Project.Rosseel_Almanzo.Core.Interfaces.Services;
using PRI.Project.Rosseel_Almanzo.Core.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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

        public EventService(IEventRepository eventRepository, IUserRepository userRepository, IEventUserRepository eventUserRepository, IAddressRepository addressRepository, IImageRepository imageRepository)
        {
            _eventRepository = eventRepository;
            _userRepository = userRepository;
            _eventUserRepository = eventUserRepository;
            _addressRepository = addressRepository;
            _imageRepository = imageRepository;
        }

        public async Task<ResultModel<Event>> CreateEventAsync(EventCreateRequestModel eventCreateRequestModel)
        {
            //check if orginazerid exists
            if (_userRepository.GetAll().Any(g => g.Id == eventCreateRequestModel.OrganizerId) == false) // waarom kan ik hier geen async gebruiken
            {
                return new ResultModel<Event>
                {
                    Success = false,
                    Errors = new List<string> { "Orginazer does not exist!" }
                };
            }

            //check dateofbirth
            if (eventCreateRequestModel.Date < DateTime.Now)
            {
                return new ResultModel<Event>
                {
                    Success = false,
                    Errors = new List<string> { "DateOfBirth cant be in the past!" }
                };
            }

            //Hier moet ik new list maken zodat ik de icollection images in mijn database/entity event niet hoef aan te passen!!!!!
            //fill imageslist with added image
            var imageList = new List<Image>();
            if (!string.IsNullOrWhiteSpace(eventCreateRequestModel.Image))
            {
                var image = new Image
                {
                    File = eventCreateRequestModel.Image,
                };
                imageList.Add(image);
            }
            
            
            //create new event (with address)
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
            var userAddress = await _addressRepository.GetByIdAsync(selectedEvent.AddressId);

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
                if (await _addressRepository.DeleteAsync(userAddress))
                {
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
                var result = await _userRepository.GetByIdAsync((int)attendingUser.UserId);
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

            //check if imagas are present
            if (eventUpdateRequestModel.Image != null)
            {
                //check if images exist in database
                var images = _eventRepository.GetAllEventImages(eventUpdateRequestModel.Id);
                var imageToDelete = images.FirstOrDefault();
                if (imageToDelete != null)
                {
                    if (!await _imageRepository.DeleteAsync(imageToDelete))
                    {
                        return new ResultModel<Event>
                        {
                            Success = false,
                            Errors = new List<string> { "Image does not exist!" }
                        };
                    }
                }             
            }

            //get the event
            var selectedEvent = await _eventRepository.GetByIdAsync(eventUpdateRequestModel.Id);
            //TODO delet old images before adding new image to selectedEvent
            var image = new Image {File = eventUpdateRequestModel.Image};
            //update
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
            selectedEvent.Images.Add(image);
            selectedEvent.Comments = _eventRepository.GetAllEventComments(eventUpdateRequestModel.Id).ToList();            

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
                Errors = new List<string> { "Record update failed!" }
            };
        }
    }
}
