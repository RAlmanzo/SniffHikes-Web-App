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
        private readonly IImageService _imageService;

        public EventsController(IEventService eventService, IWebHostEnvironment webHostEnvironment, ILogger<EventsController> logger, IFileService fileService, IImageService imageService)
        {
            _eventService = eventService;
            _webHostEnvironment = webHostEnvironment;
            _logger = logger;
            _fileService = fileService;
            _imageService = imageService;
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
            //check if images are present and store on wwwroot
            var filenames = new List<string>();
            if (eventRequestDto.Images.Count() > 0)
            {
                foreach (var image in eventRequestDto.Images)
                {
                    var imagePath = await _fileService.StoreFile<Event>(image);
                    filenames.Add(imagePath);
                }
            }

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
                    Images = filenames
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
            //get the event
            var eventResult = await _eventService.GetByIdAsync(id);
            if (!eventResult.Success)
            {
                return NotFound("User not found!");
            }

            //delete images from wwwroot
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

        [HttpPut("{id}/image")]
        public async Task<IActionResult> AddImageToEvent(int id, [FromForm] ImageRequestDto imageRequestDto)
        {
            // Check if event exists
            if (!await _eventService.CheckIfExistsAsync(id))
            {
                return NotFound("Route not found!");
            }

            // Store the uploaded image
            var imagePath = await _fileService.StoreFile<Event>(imageRequestDto.Image);

            // Update the event to add the new image
            var result = await _eventService.AddImageAsync(id, imagePath);

            if (result.Success)
            {
                return Ok(result.Value.MapToDto());
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }

            return BadRequest(ModelState.Values);
        }

        [HttpDelete("{id}/image")]
        public async Task<IActionResult> DeleteImage(int id)
        {
            //delete image from wwwroot
            var image = await _imageService.GetByIdAsync(id);
            if (image.Success)
            {
                if (!_fileService.DeleteFile<Event>(image.Value.File))
                {
                    ModelState.AddModelError("", "Image not found");
                }
            }

            //delete the image from db
            var result = await _imageService.DeleteImageAsync(id);
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

        [HttpGet("Search/ByTitle/{title}")]
        public async Task<IActionResult> SearchByTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                return BadRequest("character not allowed!");
            }
            var result = await _eventService.SearchByTitleAsync(title);
            if (result.Success)
            {
                return Ok(result.Value.MapToDto());
            }
            return Ok(result.Errors);
        }
    }
}
