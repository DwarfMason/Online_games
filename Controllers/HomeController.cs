﻿﻿using System.Diagnostics;
 using System.Threading.Tasks;
 using WebApplication1.Game;
 using Microsoft.AspNetCore.Identity;
 using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<User> _userManager;
        private CultivatorContext cultivatordb = new CultivatorContext();
        
        public async Task<ActionResult> Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var c = await cultivatordb.GetCultivator(User.Identity.Name);
                TempData["Nickname"] = c.Name;
                TempData["Gold"] = c.Gold;
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}