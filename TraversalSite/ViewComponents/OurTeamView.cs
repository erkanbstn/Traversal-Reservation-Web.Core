using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TraversalSite.ViewComponents
{
    public class OurTeamView : ViewComponent
    {
        private readonly IGuideService _guideService;

        public OurTeamView(IGuideService guideService)
        {
            _guideService = guideService;
        }

        public IViewComponentResult Invoke()
        {
            var guides = _guideService.YouCanList();
            return View(guides);
        }
    }
}
