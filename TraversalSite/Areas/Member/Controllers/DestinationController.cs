using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TraversalSite.Areas.Member.Controllers
{
    [Area("Member")]
    [AllowAnonymous]
    public class DestinationController : Controller
    {
        DestinationManager dm = new DestinationManager(new EFDestinationDal());
        public IActionResult Index()
        {
            var destinations = dm.YouCanList();
            return View(destinations);
        }
    }
}
