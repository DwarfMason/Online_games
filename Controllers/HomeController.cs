﻿using System;
 using System.Collections.Generic;
 using System.Diagnostics;
 using System.Threading.Tasks;
 using WebApplication1.Game;
 using Microsoft.AspNetCore.Identity;
 using Microsoft.AspNetCore.Mvc;
 using WebApplication1.Game.BaseClasses;
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
                if (c == null)
                {
                    CCultivator newCultivator = new CCultivator()
                    {
                        LocationId = GWorld.World.SubLocations[0].Id
                    };
                    newCultivator.PlayerId = CultivatorContext.getHex(User.Identity.Name);
                    newCultivator.Name = User.Identity.Name;
                    newCultivator.Inventory = new CCultivator.CInventory();
                    newCultivator.HeroType = User.Identity.Name; 
                    await cultivatordb.Create(newCultivator);
                }
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

        public async Task<IActionResult> RecordList()
        {
            if (User.Identity.IsAuthenticated)
            {
                var cult = await cultivatordb.GetCultivator(User.Identity.Name);
                TempData["Nickname"] = cult.Name;
                TempData["Gold"] = cult.Gold;
                var cultivators = await cultivatordb.GetAllCults();
                var enumerator = cultivators.GetEnumerator();
                List<CCultivator> topList = new List<CCultivator>();
                topList = new List<CCultivator>();
                for (; enumerator.MoveNext();)
                    topList.Add(enumerator.Current);
                topList.Sort(new Comparator());
                ViewBag.TopList = topList;
            }

            return View();
        }
    }
}