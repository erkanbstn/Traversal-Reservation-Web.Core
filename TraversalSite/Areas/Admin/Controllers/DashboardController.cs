using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TraversalSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        DestinationManager dm = new DestinationManager(new EFDestinationDal());
        public IActionResult Destination()
        {
            var values = dm.YouCanList();
            return View(values);
        }
    }
}
