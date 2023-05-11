using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace TraversalSite.ViewComponents
{
    public class AboutDestView:ViewComponent
    {
        private readonly IDestinationService _destinationService;

        public AboutDestView(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public IViewComponentResult Invoke()
        {
            var destinations = _destinationService.YouCanGetBy3();
            return View(destinations);
        }
    }
}
