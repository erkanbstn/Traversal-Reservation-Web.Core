using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TraversalSite.Controllers
{
    [AllowAnonymous]
    public class MainController : Controller
    {
        DestinationManager dm = new DestinationManager(new EFDestinationDal());
        GuideManager gm = new GuideManager(new EFGuideDal());
        UserManager um = new UserManager(new EFUserDal());
        


        public IActionResult Index()
        {
            return View();
        }
        public IActionResult About()
        {
            ViewBag.rehber = gm.YouCanList().Count;
            ViewBag.musteri = um.YouCanList().Count;
            ViewBag.tur = dm.YouCanList().Count;
            return View();
        }
        public IActionResult Services()
        {
            return View(dm.YouCanList());
        }
        public IActionResult Packages()
        {
            var destinations = dm.YouCanList();
            return View(destinations);
        }
        public IActionResult Single(int id)
        {
            if (id > 0)
            {
                var destination  = dm.YouCanGetById(id);
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
