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
    }
}
