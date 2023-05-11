using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TraversalSite.Controllers
{
    [AllowAnonymous]
    public class MainController : Controller
    {
       
        private readonly IGuideService _guideService;
        private readonly IDestinationService _destinationService;
        private readonly IUserService _userService;

        public MainController(IGuideService guideService, IDestinationService destinationService, IUserService userService)
        {
            _guideService = guideService;
            _destinationService = destinationService;
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult About()
        {
            ViewBag.rehber = _guideService.YouCanList().Count;
            ViewBag.musteri = _userService.YouCanList().Count;
            ViewBag.tur = _destinationService.YouCanList().Count;
            return View();
        }
        public IActionResult Services()
        {
            return View(_destinationService.YouCanList());
        }
        public IActionResult Packages()
        {
            var destinations = _destinationService.YouCanList();
            return View(destinations);
        }
        public IActionResult Single(int id)
        {
            if (id > 0)
            {
                var destination  = _destinationService.YouCanGetById(id);
                return View(destination);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Contact()
        {
            return View();
        }
    }
}
