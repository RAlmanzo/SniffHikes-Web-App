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
        private readonly IAddressRepository _addressRepository;

        public EventService(IEventRepository eventRepository, IUserRepository userRepository)
        {
            _eventRepository = eventRepository;
            _userRepository = userRepository;
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

            //create new event (with address)
            var newEvent = new Event
            {
                Title = eventCreateRequestModel.Title,
                Description = eventCreateRequestModel.Description,
                Price = eventCreateRequestModel.Price,
                Address = new Address
                {
                    Street = eventCreateRequestModel.Street,
                    City = eventCreateRequestModel.City,
                    State = eventCreateRequestModel.State,
                    Country = eventCreateRequestModel.Country,
                },
                Date = eventCreateRequestModel.Date,
                OrganizerId = eventCreateRequestModel.OrganizerId,
            };
            //call the eventsrepo addAsync method for the event  and addres (images,...)
            var result = await _eventRepository.AddAsync(newEvent);
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

            //check iff event exists
            if (selectedEvent == null)
            {
                return new ResultModel<Event>
                {
                    Success = false,
                    Errors = new List<string> { "Event does not exist!" }
                };
            }

            //check if deleteAsync returns true
            if(await _eventRepository.DeleteAsync(selectedEvent))
            {
                return new ResultModel<Event> { Success = true, };
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
            //if yes
            eventResultModel.Success = true;
            eventResultModel.Value = selectedEvent;
            return eventResultModel;
        }
    }
}
