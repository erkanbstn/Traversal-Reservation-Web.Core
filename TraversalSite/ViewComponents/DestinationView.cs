using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TraversalSite.ViewComponents
{
    public class DestinationView : ViewComponent
    {
        private readonly IDestinationService _destinationService;

        public DestinationView(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public IViewComponentResult Invoke()
        {
            var destinations = _destinationService.YouCanList();
            return View(destinations);
        }
    }
}
