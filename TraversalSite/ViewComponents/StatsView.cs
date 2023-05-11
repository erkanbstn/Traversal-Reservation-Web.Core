using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace TraversalSite.ViewComponents
{
    public class StatsView : ViewComponent
    {
        private readonly IDestinationService _destinationService;
        private readonly IGuideService _guideService;
        private readonly IUserService _userService;

        public StatsView(IDestinationService destinationService, IGuideService guideService, IUserService userService)
        {
            _destinationService = destinationService;
            _guideService = guideService;
            _userService = userService;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.guides = _guideService.YouCanList().Count;
            ViewBag.destinations = _destinationService.YouCanList().Count;
            ViewBag.clients = _userService.YouCanList().Count;
            ViewBag.awards = "28";

            return View();
        }
    }
}
