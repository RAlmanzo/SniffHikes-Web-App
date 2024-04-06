using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRI.Project.Rosseel_Almanzo.Api.Extensions;
using PRI.Project.Rosseel_Almanzo.Core.Interfaces.Services;
using PRI.Project.Rosseel_Almanzo.Core.Services;

namespace PRI.Project.Rosseel_Almanzo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoutesController : ControllerBase
    {
        private readonly IRouteService _routeService;

        public RoutesController(IRouteService routeService)
        {
            _routeService = routeService;
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
    }
}
