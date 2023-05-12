using DtoLayer.Dtos.AppUserDto;
using DtoLayer.Dtos.MailDto;
using EntityLayer.Concrete;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System.Threading.Tasks;


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
        public async Task<IActionResult> Login(UserLoginDto user)
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
        public async Task<IActionResult> Register(UserRegisterDto user)
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
            // Mail

            //MimeMessage mime = new MimeMessage();
            //MailDto mail = new MailDto()
            //{
            //    Name = "Traversal",
            //    Body="Hesaptan Çıkış Yapıldı.",
            //    SenderMail = "traversalcore2@gmail.com",
            //    ReceiverMail = "test34@gmail.com",
            //    Subject = "Traversal Mail"
            //};
            //MailboxAddress mailboxFrom = new MailboxAddress(mail.Name, mail.SenderMail);
            //MailboxAddress mailboxTo = new MailboxAddress("User", mail.ReceiverMail);
            //mime.From.Add(mailboxFrom);
            //mime.To.Add(mailboxTo);
            //var bodyBuilder = new BodyBuilder();
            //bodyBuilder.TextBody = mail.Body;
            //mime.Body=bodyBuilder.ToMessageBody();
            //mime.Subject = mail.Subject;
            //SmtpClient client = new SmtpClient();
            //client.Connect("smtp.gmail.com", 587, false);
            //client.Authenticate(mail.SenderMail, "fhvevuwmjwlkpnzm");
            //client.Send(mime);
            //client.Disconnect(true);

            await _signInManager.SignOutAsync(); 
            return RedirectToAction("Login");
        }
    }
}
