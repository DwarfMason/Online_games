﻿using System.Diagnostics;
 using AdministratorProject.Game;
 using Microsoft.AspNetCore.Identity;
 using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<User> _userManager;
        private CultivatorContext cultivatordb = new CultivatorContext();
        
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                TempData["Nickname"] = cultivatordb.GetName(User.Identity.Name);
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