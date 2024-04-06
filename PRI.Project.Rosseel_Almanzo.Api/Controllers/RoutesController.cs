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
    }
}
