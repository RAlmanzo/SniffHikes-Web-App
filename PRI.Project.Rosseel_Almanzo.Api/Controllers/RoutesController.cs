using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRI.Project.Rosseel_Almanzo.Api.Dtos;
using PRI.Project.Rosseel_Almanzo.Api.Extensions;
using PRI.Project.Rosseel_Almanzo.Api.Services.Interfaces;
using PRI.Project.Rosseel_Almanzo.Core.Entities;
using PRI.Project.Rosseel_Almanzo.Core.Interfaces.Services;
using PRI.Project.Rosseel_Almanzo.Core.Services;
using PRI.Project.Rosseel_Almanzo.Core.Services.Models;
using Route = PRI.Project.Rosseel_Almanzo.Core.Entities.Route;

namespace PRI.Project.Rosseel_Almanzo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoutesController : ControllerBase
    {
        private readonly IRouteService _routeService;
        private readonly IFileService _fileService;
       

        public RoutesController(IRouteService routeService, IFileService fileService)
        {
            _routeService = routeService;
            _fileService = fileService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //get all events
            var result = await _routeService.GetAllAsync();
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
            var result = await _routeService.GetByIdAsync(id);
            //check if result is succes
            if (result.Success)
            {
                return Ok(result.Value.MapToDto());
            }
            return NotFound(result.Errors);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromForm]RouteRequestDto routeRequestDto)
        {
            //check if images are given and store in wwwroot
            var filenames = new List<string>();
            if (routeRequestDto.Images.Count() > 0)
            {
                foreach (var image in routeRequestDto.Images)
                {
                    var imagePath = await _fileService.StoreFile<Route>(image);
                    filenames.Add(imagePath);
                }
            }

            var result = await _routeService.CreateRouteAsync(
                new RouteCreateRequestModel
                {
                    Title = routeRequestDto.Title,
                    Description = routeRequestDto.Description,
                    Street = routeRequestDto.Address.Street,
                    City = routeRequestDto.Address.City,
                    State = routeRequestDto.Address.State,
                    Country = routeRequestDto.Address.Country,
                    OrganizerId = routeRequestDto.OrganizerId,
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
            //get the route
            var route = await _routeService.GetByIdAsync(id);
            if (!route.Success)
            {
                return NotFound("User not found!");
            }

            //delete images from wwwroot
            foreach (var image in route.Value.Images)
            {
                if (!string.IsNullOrWhiteSpace(image.File))
                {
                    if (!_fileService.DeleteFile<User>(image.File))
                    {
                        ModelState.AddModelError("", "Image not found");
                    }
                }
            }

            var result = await _routeService.DeleteRouteAsync(id);
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
        public async Task<IActionResult> Update([FromForm]RouteUpdateRequestDto routeUpdateRequestDto)
        {
            //check if route exists
            if (!await _routeService.CheckIfExistsAsync(routeUpdateRequestDto.Id))
            {
                return NotFound("Event not found!");
            }

            ////check if new route images
            //var filenames = new List<string>();
            //if (routeUpdateRequestDto.Images.Count() > 0)
            //{
            //    //get route
            //    var selectedEvent = await _eventService.GetByIdAsync(eventUpdateRequestDto.Id);
            //    //delete current image
            //    foreach (var image in selectedEvent.Value.Images)
            //    {
            //        if (!string.IsNullOrWhiteSpace(image.File))
            //        {
            //            if (!_fileService.DeleteFile<User>(image.File))
            //            {
            //                ModelState.AddModelError("", "Image not found");
            //            }
            //        }
            //    }
            //    //save new image
            //    filename = await _fileService.StoreFile<User>(eventUpdateRequestDto.Image);
            //}

            var result = await _routeService.UpdateRouteAsync
            (
                new RouteUpdateRequestModel
                {
                    Id = routeUpdateRequestDto.Id,
                    Title = routeUpdateRequestDto.Title,
                    Description = routeUpdateRequestDto.Description,
                    Street = routeUpdateRequestDto.Address.Street,
                    City = routeUpdateRequestDto.Address.City,
                    State = routeUpdateRequestDto.Address.State,
                    Country = routeUpdateRequestDto.Address.Country,
                    OrganizerId = routeUpdateRequestDto.OrganizerId,
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

        [HttpPut("{id}/images")]
        public async Task<IActionResult> AddImageToRoute(int id, [FromForm]ImageRequestDto imageRequestDto)
        {
            // Check if route exists
            if (!await _routeService.CheckIfExistsAsync(id))
            {
                return NotFound("Route not found!");
            }

            // Store the uploaded image
            var imagePath = await _fileService.StoreFile<Route>(imageRequestDto.Image);

            // Update the route to add the new image
            var result = await _routeService.AddImage(id, imagePath);

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
    }
}
