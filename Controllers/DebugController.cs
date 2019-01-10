using System.Threading.Tasks;
using AdministratorProject.Game;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class DebugController : Controller
    {
        private readonly UserManager<User> _userManager;
        private CultivatorContext cultivatordb = new CultivatorContext();
        
        [Authorize]
        public IActionResult Index()
        {
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

    }
}