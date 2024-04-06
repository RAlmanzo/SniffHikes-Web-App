using Microsoft.AspNetCore.Mvc;
using PRI.Project.Rosseel_Almanzo.Api.Dtos;
using PRI.Project.Rosseel_Almanzo.Api.Extensions;
using PRI.Project.Rosseel_Almanzo.Api.Services.Interfaces;
using PRI.Project.Rosseel_Almanzo.Core.Entities;
using PRI.Project.Rosseel_Almanzo.Core.Interfaces.Services;
using PRI.Project.Rosseel_Almanzo.Core.Services;
using PRI.Project.Rosseel_Almanzo.Core.Services.Models;
using System;

namespace PRI.Project.Rosseel_Almanzo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : Controller
    {
        private readonly IEventService _eventService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ILogger<EventsController> _logger;
        private readonly IFileService _fileService;

        public EventsController(IEventService eventService, IWebHostEnvironment webHostEnvironment, ILogger<EventsController> logger, IFileService fileService)
        {
            _eventService = eventService;
            _webHostEnvironment = webHostEnvironment;
            _logger = logger;
            _fileService = fileService;
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
        public async Task<IActionResult> Add([FromForm]EventRequestDto eventRequestDto)
        {
            //check if image is present
            var filename = "";
            if (eventRequestDto.Image != null)
            {
                filename = await _fileService.StoreFile<Event>(eventRequestDto.Image);
            }

            ////Dit is de code die ik zou gebruiken als ik een list van images kan meegeven in swagger!!!
            ////check if images are given
            //var filenames = "";
            //if (eventRequestDto.ImageUrls != null)
            //{
            //    foreach (var url in eventRequestDto.ImageUrls)
            //    {
            //        filename += await _fileService.StoreFile<Event>(url);
            //    }
            //}

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
                    Image = filename
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
            var eventResult = await _eventService.GetByIdAsync(id);

            if (!eventResult.Success)
            {
                return NotFound("User not found!");
            }

            foreach(var image in eventResult.Value.Images)
            {
                if (!string.IsNullOrWhiteSpace(image.File))
                {
                    if (!_fileService.DeleteFile<User>(image.File))
                    {
                        ModelState.AddModelError("", "Image not found");
                    }
                }
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
        public async Task<IActionResult> Update([FromForm]EventUpdateRequestDto eventUpdateRequestDto)
        {
            //check if event exists
            if (!await _eventService.CheckIfExistsAsync(eventUpdateRequestDto.Id))
            {
                return NotFound("Event not found!");
            }
            
            //check if new user image
            var filename = "";
            if (eventUpdateRequestDto.Image != null)
            {
                //get event
                var selectedEvent = await _eventService.GetByIdAsync(eventUpdateRequestDto.Id);
                //delete current image
                foreach (var image in selectedEvent.Value.Images)
                {
                    if (!string.IsNullOrWhiteSpace(image.File))
                    {
                        if (!_fileService.DeleteFile<User>(image.File))
                        {
                            ModelState.AddModelError("", "Image not found");
                        }
                    }
                }             
                //save new image
                filename = await _fileService.StoreFile<User>(eventUpdateRequestDto.Image);
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
                    //ImageIds = eventUpdateRequestDto.ImageIds,
                    Image = filename,
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
