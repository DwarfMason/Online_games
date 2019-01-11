using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Game;
using WebApplication1.Game.BaseClasses;

namespace WebApplication1.Controllers
{
    public class GameController : Controller
    {
        private CultivatorContext cultivatordb = new CultivatorContext();
        
        public async Task<IActionResult> Index()
        {
            var cult = await cultivatordb.GetCultivator(User.Identity.Name);
            var location = GLocationsList.GetById(cult.LocationId);
            var seller = location.SubLocations
            TempData["Name"] = location.Name;
            return
            View("~/Views/Game/Town.cshtml");
        }
    }
}