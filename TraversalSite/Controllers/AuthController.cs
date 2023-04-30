using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TraversalSite.Models;

namespace TraversalSite.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AuthController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;

        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginViewModel user)
        {
            if (user.Password != "" && user.UserName != "")
            {
                var result = await _signInManager.PasswordSignInAsync(user.UserName, user.Password, false, true);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Destination", new { area = "Member" });
                }
            }
            return View(user);
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterViewModel user)
        {
            AppUser app = new AppUser()
            {
                UserName = user.UserName,
                Email = user.Email,
            };
            if (user.Password == user.ConfirmPassword)
            {
                var result = await _userManager.CreateAsync(app, user.Password);
                if (result.Succeeded)
                {
                    ViewBag.error = 0;
                    return RedirectToAction("Login");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(user);
        }

        public async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
