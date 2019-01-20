using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Game;
using WebApplication1.Game.BaseClasses;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class DebugController : Controller
    {
        private readonly UserManager<User> _userManager;
        private CultivatorContext cultivatordb = new CultivatorContext();
        
        [Authorize]
        public async Task<IActionResult> Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var c = await cultivatordb.GetCultivator(User.Identity.Name);
                TempData["Nickname"] = c.Name;
                TempData["Gold"] = c.Gold;
            }
            return View();
        }
        
        [Authorize]
        public async Task<ActionResult> Add1MGold()
        {
            var cult = await cultivatordb.GetCultivator(User.Identity.Name);
            cult.Gold += 1000000;
            await cultivatordb.Update(cult);
            return RedirectToAction("Index", "Debug");
        }
        
        [Authorize]
        public async Task<ActionResult> LoseGold()
        {
            var cult = await cultivatordb.GetCultivator(User.Identity.Name);
            cult.Gold = 0;
            await cultivatordb.Update(cult);
            return RedirectToAction("Index", "Debug");
        }
        
        [Authorize]
        public async Task<ActionResult> FightMob()
        {
            var cult = await cultivatordb.GetCultivator(User.Identity.Name);
            var location = new СEventLocation();
            location.CreateAdventure(cult);
            await cultivatordb.Update(cult);
            return RedirectToAction("Index", "Debug");
        }

    }
}