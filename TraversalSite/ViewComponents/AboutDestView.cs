using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace TraversalSite.ViewComponents
{
    public class AboutDestView:ViewComponent
    {
        DestinationManager dm = new DestinationManager(new EFDestinationDal());
        public IViewComponentResult Invoke()
        {
            var destinations = dm.YouCanGetBy3();
            return View(destinations);
        }
    }
}
