using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class GameController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return
            View("~/Views/Game/Town.cshtml");
        }
    }
}