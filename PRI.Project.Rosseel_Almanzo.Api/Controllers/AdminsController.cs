using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRI.Project.Rosseel_Almanzo.Api.Extensions;
using PRI.Project.Rosseel_Almanzo.Api.Services.Interfaces;
using PRI.Project.Rosseel_Almanzo.Core.Entities;
using PRI.Project.Rosseel_Almanzo.Core.Interfaces.Services;

namespace PRI.Project.Rosseel_Almanzo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminsController : ControllerBase
    {
        private readonly IEventService _eventService;
        private readonly IRouteService _routeService;
        private readonly IUserService _userService;
        private readonly IFileService _fileService;

        public AdminsController(IEventService eventService, IRouteService routeService, IUserService userService)
        {
            _eventService = eventService;
            _routeService = routeService;
            _userService = userService;
        }

        [HttpGet("events")]
        public async Task<IActionResult> GetAllEvents()
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

        [HttpGet("{id}/event")]
        public async Task<IActionResult> GetEvent(int id)
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

        [HttpDelete("{id}/event")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            //get the event
            var eventResult = await _eventService.GetByIdAsync(id);
            if (!eventResult.Success)
            {
                return NotFound("User not found!");
            }

            //delete images from wwwroot
            foreach (var image in eventResult.Value.Images)
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

        [HttpGet("routes")]
        public async Task<IActionResult> GetAllRoutes()
        {
            //get all routes
            var result = await _routeService.GetAllAsync();
            //check if result is succes
            if (result.Success)
            {
                return Ok(result.Value.MapToDto());
            }
            return NotFound(result.Errors);
        }

        [HttpGet("{id}/route")]
        public async Task<IActionResult> GetRoute(int id)
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

        [HttpDelete("{id}/route")]
        public async Task<IActionResult> DeleteRoute(int id)
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

        [HttpGet("users")]
        public async Task<IActionResult> GetAllUsers()
        {
            //get all users
            var result = await _userService.GetAllAsync();
            //check if result is succes
            if (result.Success)
            {
                return Ok(result.Value.MapToDto());
            }
            return NotFound(result.Errors);
        }

        [HttpGet("{id}/user")]
        public async Task<IActionResult> GetUser(int id)
        {
            //get the record
            var result = await _userService.GetByIdAsync(id);
            //check if result is succes
            if (result.Success)
            {
                return Ok(result.Value.MapToDto());
            }
            return NotFound(result.Errors);
        }

        [HttpDelete("{id}/user")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var userResult = await _userService.GetByIdAsync(id);

            if (!userResult.Success)
            {
                return NotFound("User not found!");
            }

            if (!string.IsNullOrWhiteSpace(userResult.Value.Image))
            {
                if (!_fileService.DeleteFile<User>(userResult.Value.Image))
                {
                    ModelState.AddModelError("", "Image not found");
                }
            }

            if (userResult.Value.Dogs.Count() > 0)
            {
                foreach (var dog in userResult.Value.Dogs)
                {
                    if (!string.IsNullOrWhiteSpace(dog.Image))
                    {
                        if (!_fileService.DeleteFile<User>(dog.Image))
                        {
                            ModelState.AddModelError("", "Image not found");
                        }
                    }
                }
            }
            //TODO Delete dog images

            var result = await _userService.DeleteUserAsync(id);
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
