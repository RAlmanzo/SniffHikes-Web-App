using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRI.Project.Rosseel_Almanzo.Core.Interfaces.Services;

namespace PRI.Project.Rosseel_Almanzo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ILogger<EventsController> _logger;

        public UsersController(IUserService userService, IWebHostEnvironment webHostEnvironment, ILogger<EventsController> logger)
        {
            _userService = userService;
            _webHostEnvironment = webHostEnvironment;
            _logger = logger;
        }

        
    }
}
