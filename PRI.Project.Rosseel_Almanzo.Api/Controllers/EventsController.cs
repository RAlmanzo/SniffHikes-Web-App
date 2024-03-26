using Microsoft.AspNetCore.Mvc;
using PRI.Project.Rosseel_Almanzo.Api.Dtos;
using PRI.Project.Rosseel_Almanzo.Api.Extensions;
using PRI.Project.Rosseel_Almanzo.Core.Interfaces.Services;
using PRI.Project.Rosseel_Almanzo.Core.Services.Models;

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
            //check if result is succes
            if (result.Success)
            {
                return Ok(result.Value.MapToDto());
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
                return Ok(result.Value.MapToDto());
            }
            return NotFound(result.Errors);
        }

        [HttpPost]
        public async Task<IActionResult> Add(EventRequestDto eventRequestDto)
        {
            var result = await _eventService.CreateEventAsync(
                new EventCreateRequestModel
                {
                    Title = eventRequestDto.Title,
                    Description = eventRequestDto.Description,
                    Price = eventRequestDto.Price,
                    Street = eventRequestDto.Address.Street,
                    City = eventRequestDto.Address.City,
                    State = eventRequestDto.Address.State,
                    Country = eventRequestDto.Address.Country,
                    OrganizerId = eventRequestDto.OrganizerId,
                    Date = eventRequestDto.Date,
                });

            if (result.Success)
            {
                return CreatedAtAction(nameof(Get), new { ID = result.Value.Id }, result.Value
                    .MapToDto());
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
            return BadRequest(ModelState.Values);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!await _eventService.CheckIfExistsAsync(id))
            {
                return NotFound("Event not found!");
            }

            var result = await _eventService.DeleteEventAsync(id);
            if (result.Success)
            {
                return Ok();
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
            return BadRequest(ModelState.Values);
        }

        [HttpPut]
        public async Task<IActionResult> Update(EventUpdateRequestDto eventUpdateRequestDto)
        {
            //check if event exists
            if (!await _eventService.CheckIfExistsAsync(eventUpdateRequestDto.Id))
            {
                return NotFound("Event not found!");
            }

            var result = await _eventService.UpdateEventAsync
                (
                    new EventUpdateRequestModel
                    {
                        Id = eventUpdateRequestDto.Id,
                        Title = eventUpdateRequestDto.Title,
                        Description = eventUpdateRequestDto.Description,
                        Price = eventUpdateRequestDto.Price,
                        Street = eventUpdateRequestDto.Address.Street,
                        City = eventUpdateRequestDto.Address.City,
                        State = eventUpdateRequestDto.Address.State,
                        Country = eventUpdateRequestDto.Address.Country,
                        OrganizerId = eventUpdateRequestDto.OrganizerId,
                        Date = eventUpdateRequestDto.Date,
                        DateCreated = eventUpdateRequestDto.DateCreated,
                        ImageIds = eventUpdateRequestDto.ImageIds,
                        CommentIds = eventUpdateRequestDto.CommentIds,
                        AttendingUserIds = eventUpdateRequestDto.AttendingUserIds,
                    }
                );
            if (result.Success)
            {
                return Ok();
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
            return BadRequest(ModelState.Values);
        }
    }
}
