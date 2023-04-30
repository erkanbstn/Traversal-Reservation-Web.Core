using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;
using TraversalSite.Areas.Member.Models;

namespace TraversalSite.Areas.Member.Controllers
{
    [Area("Member")]
    [Route("Member/[controller]/[action]")]
    [AllowAnonymous]
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public ProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditViewModel user = new UserEditViewModel
            {
                Name = values.Name,
                Email = values.Email,
                Phone = values.PhoneNumber,
                ImageUrl = values.Image,
            };
            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel u)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (u.Image != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(u.Image.FileName);
                var imageName = Guid.NewGuid() + extension;
                var saveLocation = resource + "/wwwroot/Tra/assets/images/" + imageName;
                var stream = new FileStream(saveLocation, FileMode.Create);
                await u.Image.CopyToAsync(stream);
                user.Image = imageName;
            }
            user.Name = u.Name;
            user.PhoneNumber = u.Phone;
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, u.Password);
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
