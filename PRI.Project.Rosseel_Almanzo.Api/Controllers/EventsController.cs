using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Index()
        {
            return View();
        }
    }
}
