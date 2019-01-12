using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Game;
using WebApplication1.Game.BaseClasses;

namespace WebApplication1.Controllers
{
    public class GameController : Controller
    {
        private CultivatorContext cultivatordb = new CultivatorContext();
        
        public async Task<IActionResult> Town()
        {
            var cult = await cultivatordb.GetCultivator(User.Identity.Name);
            var location = GLocationsList.GetById(cult.LocationId);
            var seller = location.SubLocations[0];
            TempData["Nickname"] = cult.Name;
            TempData["Gold"] = cult.Gold;
            return
            View();
        }

        public async Task<IActionResult> Shop()
        {
            var cult = await cultivatordb.GetCultivator(User.Identity.Name);
            TempData["Gold"] = cult.Gold;
            TempData["Nickname"] = cult.Name;
            return View();
        }

        public async Task<IActionResult> Buy()
        {
            var cult = await cultivatordb.GetCultivator(User.Identity.Name);
            var location = GLocationsList.GetById(cult.LocationId);
            var seller = location.SubLocations[0].SubLocations[0];
            seller.Actions[0].Do(cult);
            await cultivatordb.Update(cult);
            TempData["Gold"] = cult.Gold;
            return RedirectToAction("Shop");
        }
    }
}