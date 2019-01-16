using System;
using System.Threading.Tasks;
using WebApplication1.Game.UpdateClasses.Buildings;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Game;
using WebApplication1.Game.BaseClasses;
using WebApplication1.Game.UpdateClasses.NPC;

namespace WebApplication1.Controllers
{
    public class GameController : Controller
    {
        private CultivatorContext cultivatordb = new CultivatorContext();
        
        public async Task<IActionResult> go(int? Id)
        {
            var cult = await cultivatordb.GetCultivator(User.Identity.Name);
            if (Id != null)
            {
                cult.LocationId = (int)Id;
                await cultivatordb.Update(cult);
            }

            if (cult.LocationId == 0)
            {
                cult.LocationId = 1;
                await cultivatordb.Update(cult);
            }
            var location = GLocationsList.GetById(cult.LocationId);
            if (location is CBuilding)
            {
                if (location is CTown)
                {
                    return RedirectToAction("Town", cult);
                }

                if (location is CMarket)
                {
                    return RedirectToAction("Market", cult);
                }
            }

            if (location is CNPC)
            {
                if (location is CBaseTrader)
                {
                    return RedirectToAction("Shop", cult);
                }
            }

            throw new Exception("This Location is unknown");
        }   
        
        public async Task<IActionResult> Town(CCultivator cult)
        {
            TempData["Gold"] = cult.Gold;
            TempData["Nickname"] = cult.Name;
            CTown location = (CTown)GLocationsList.GetById(cult.LocationId);
            return View(location);
        }
        
        public async Task<IActionResult> Market(CCultivator cult)
        {
            TempData["Gold"] = cult.Gold;
            TempData["Nickname"] = cult.Name;
            CMarket location = (CMarket)GLocationsList.GetById(cult.LocationId);
            return View(location);
        }

        public async Task<IActionResult> Shop(CCultivator cult)
        {
            TempData["Gold"] = cult.Gold;
            TempData["Nickname"] = cult.Name;
            return View((CBaseTrader)GLocationsList.GetById(cult.LocationId));
        }
        
        [HttpPost]
        public async Task<IActionResult> Shop(int slot)
        {
            var cult = await cultivatordb.GetCultivator(User.Identity.Name);
            var seller = GLocationsList.GetById(cult.LocationId);
            seller.Actions[slot].Do(cult);
            await cultivatordb.Update(cult);
            TempData["Gold"] = cult.Gold;
            TempData["Nickname"] = cult.Name;
            return View((CBaseTrader)GLocationsList.GetById(cult.LocationId));
        }
        
        public async Task<IActionResult> Beastiary()
        {
            var cult = await cultivatordb.GetCultivator(User.Identity.Name);
            TempData["Gold"] = cult.Gold;
            TempData["Nickname"] = cult.Name;
            return View();
        }
    }
}