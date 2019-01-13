using System;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplication1.Game;
using WebApplication1.Game.BaseClasses;
using Microsoft.AspNetCore.Authorization;
using WebApplication1.ViewModels;
using WebApplication1.Models;
using Microsoft.AspNetCore.Identity;

namespace WebApplication1.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private CultivatorContext cultivatordb = new CultivatorContext();
 
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            return View(new LoginViewModel {ReturnUrl = returnUrl});
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var a = GWorld.World;
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    // проверяем, принадлежит ли URL приложению
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Profile", "Account");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Error credentials");
                }
            }
            return View(model);
        }
    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOff()
        {
            // удаляем аутентификационные куки
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if(ModelState.IsValid)
            {
                User user = new User { Email = model.Email, UserName = model.Email, Nickname = model.Nickname, HeroType = model.HeroType};
                // добавляем пользователя
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    // установка куки
                    await _signInManager.SignInAsync(user, false);
                    CCultivator newCultivator = new CCultivator()
                    {
                        LocationId = GWorld.World.SubLocations[0].Id
                    };
                    newCultivator.PlayerId = CultivatorContext.getHex(user.UserName);
                    newCultivator.Name = user.Nickname;
                    newCultivator.Inventory = new CCultivator.CInventory();
                    newCultivator.HeroType = user.HeroType; 
                    await cultivatordb.Create(newCultivator);
                    return RedirectToAction("Profile", "Account");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult> Profile(string id)
        {
            var cult = await cultivatordb.GetCultivator(User.Identity.Name);
            TempData["Nickname"] = cult.Name;
            TempData["Strength"] = cult.Stats.MainStats.Strength;
            TempData["Agility"] = cult.Stats.MainStats.Agility;
            TempData["Intelligence"] = cult.Stats.MainStats.Intelligence;
            TempData["Endurance"] = cult.Stats.MainStats.Endurance;
            TempData["Gold"] = cult.Gold;
            TempData["Tier"] = cult.Tier;
            TempData["HeroType"] = cult.HeroType;
            return View();
        }

        public async Task<ActionResult> IncreaseAgility ()
        {
            var cult = await cultivatordb.GetCultivator(User.Identity.Name);
            var statPrice = CCultivator.GetStatPrice(cult.Stats.MainStats.Agility);
            if (cult.Gold >= statPrice) 
            {
                cult.Gold -= statPrice;
                cult.Stats.MainStats.Agility++;
                await cultivatordb.Update(cult);
            }
            return RedirectToAction("Profile", "Account");
        }
        public async Task<ActionResult> IncreaseStrength()
        {
            var cult = await cultivatordb.GetCultivator(User.Identity.Name);
            var statPrice = CCultivator.GetStatPrice(cult.Stats.MainStats.Strength);
            if (cult.Gold >= statPrice)
            {
                cult.Gold -= statPrice;
                cult.Stats.MainStats.Strength++;
                await cultivatordb.Update(cult);
            }
            return RedirectToAction("Profile", "Account");
        }
        
        public async Task<ActionResult> IncreaseIntelligence()
        {
            var cult = await cultivatordb.GetCultivator(User.Identity.Name);
            var statPrice = CCultivator.GetStatPrice(cult.Stats.MainStats.Intelligence);
            if (cult.Gold >= statPrice)
            {
                cult.Gold -= statPrice;
                cult.Stats.MainStats.Intelligence++;
                await cultivatordb.Update(cult);
            }
            return RedirectToAction("Profile", "Account");
        }
        
        public async Task<ActionResult> IncreaseEndurance()
        {
            var cult = await cultivatordb.GetCultivator(User.Identity.Name);
            var statPrice = CCultivator.GetStatPrice(cult.Stats.MainStats.Endurance);
            if (cult.Gold >= statPrice)
            {
                cult.Gold -= statPrice;
                cult.Stats.MainStats.Endurance++;
                await cultivatordb.Update(cult);
            }
            return RedirectToAction("Profile", "Account");
        }
        
        public IActionResult Profile()
        {
            return View();
        }

        
    }
}