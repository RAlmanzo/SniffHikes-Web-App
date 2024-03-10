using Microsoft.AspNetCore.Mvc;

namespace PRI.Project.Rosseel_Almanzo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
