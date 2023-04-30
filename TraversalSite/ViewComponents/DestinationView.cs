using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TraversalSite.ViewComponents
{
    public class DestinationView : ViewComponent
    {
        DestinationManager dm = new DestinationManager(new EFDestinationDal());

        public IViewComponentResult Invoke()
        {
            var destinations = dm.YouCanList();
            return View(destinations);
        }
    }
}
