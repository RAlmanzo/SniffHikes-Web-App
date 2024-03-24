using Microsoft.AspNetCore.Mvc;
using PRI.Project.Rosseel_Almanzo.Api.Dtos;
using PRI.Project.Rosseel_Almanzo.Api.Extensions;
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

        //[HttpPost]
        //public async Task<IActionResult> Add(RecordRequestDto recordRequestDto)
        //{
        //    var result = await _recordService.CreateRecordAsync(
        //        new RecordCreateRequestModel
        //        {
        //            Title = recordRequestDto.Title,
        //            Price = recordRequestDto.Price,
        //            GenreId = recordRequestDto.GenreId,
        //            ArtistId = recordRequestDto.ArtistId,
        //            PropertyIds = recordRequestDto.PropertyIds,
        //        });
        //    if (result.IsSucces)
        //    {
        //        return CreatedAtAction(nameof(Get), new { ID = result.Value.Id }, result.Value
        //            .MapToDto());
        //    }
        //    foreach (var error in result.Errors)
        //    {
        //        ModelState.AddModelError("", error);
        //    }
        //    return BadRequest(ModelState.Values);
        //}
    }
}
