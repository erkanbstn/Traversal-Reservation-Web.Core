using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TraversalSite.ViewComponents
{
    public class OurTeamView : ViewComponent
    {
        GuideManager gm = new GuideManager(new EFGuideDal());
        public IViewComponentResult Invoke()
        {
            var guides = gm.YouCanList();
            return View(guides);
        }
    }
}
