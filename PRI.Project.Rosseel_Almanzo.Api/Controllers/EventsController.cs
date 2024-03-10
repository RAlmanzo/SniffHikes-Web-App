using Microsoft.AspNetCore.Mvc;
using PRI.Project.Rosseel_Almanzo.Api.Dtos;
using PRI.Project.Rosseel_Almanzo.Core.Interfaces.Services;

namespace PRI.Project.Rosseel_Almanzo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : Controller
    {
        private readonly IEventService _eventService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ILogger<EventsController> _logger;

        public EventsController(IEventService eventService, IWebHostEnvironment webHostEnvironment, ILogger<EventsController> logger)
        {
            _eventService = eventService;
            _webHostEnvironment = webHostEnvironment;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //get all events
            var result = await _eventService.GetAllAsync();
            //create new eventsgetallresponsedto
            //check if result is succes
            if (result.Success)
            {
                var eventsGetAllResponseDto = new EventsGetAllResponseDto
                {
                    Events = result.Value.Select(e => new BaseDto
                    {
                        Id = e.Id,
                        Value = e.Title,
                    })
                };
                return Ok(eventsGetAllResponseDto);
            }
            return NotFound(result.Errors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            //get the record
            var result = await _eventService.GetByIdAsync(id);
            //check if result is succes
            if (result.Success)
            {
                var eventsGetResponseDto = new EventsGetResponseDto
                {
                    Id = result.Value.Id,
                    Value = result.Value.Title,
                    Description = result.Value.Description,
                    Price = result.Value.Price,
                    Date = result.Value.Date,
                    DateCreated = DateTime.Now,
                    Orginazer = new BaseDto
                    {
                        Id = result.Value.OrganizerId,
                        Value = $"{result.Value.Organizer.FirstName} {result.Value.Organizer.LastName}",
                    },
                    Address = new BaseDto
                    {
                        Id = result.Value.Address.Id,
                        Value = $"{result.Value.Address.Street} {result.Value.Address.City} {result.Value.Address.State} {result.Value.Address.Country}",
                    },
                    Images = result.Value.Images.Select(i => new BaseDto
                    {
                        Id = i.Id,
                        Value = i.File,
                    }),
                    Comments = result.Value.Comments.Select(i => new BaseDto
                    {
                        Id = i.Id,
                        Value = i.Content,
                    }),
                    Users = result.Value.Users.Select(i => new BaseDto
                    {
                        Id = i.Id,
                        Value = $"{i.FirstName} {i.LastName}",
                    }),
                };
                return Ok(eventsGetResponseDto);
            }
            return NotFound(result.Errors);
        }
    }
}
