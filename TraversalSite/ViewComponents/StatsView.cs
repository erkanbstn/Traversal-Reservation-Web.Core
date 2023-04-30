using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace TraversalSite.ViewComponents
{
    public class StatsView : ViewComponent
    {
        DestinationManager dm = new DestinationManager(new EFDestinationDal());
        GuideManager gm = new GuideManager(new EFGuideDal());
        UserManager um = new UserManager(new EFUserDal());
        public IViewComponentResult Invoke()
        {
            ViewBag.guides = gm.YouCanList().Count;
            ViewBag.destinations = dm.YouCanList().Count;
            ViewBag.clients = um.YouCanList().Count;
            ViewBag.awards = "28";

            return View();
        }
    }
}
