using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TraversalSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DestinationController : Controller
    {
        private readonly IDestinationService _destinationService;

        public DestinationController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public IActionResult Index()
        {
            var values = _destinationService.YouCanList();
            return View(values);
        }
        public IActionResult AddDestination()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddDestination(Destination destination)
        {
            _destinationService.YouCanInsert(destination);
            return RedirectToAction("Index");
        }
        public IActionResult UpdateDestination(int id)
        {
            return View(_destinationService.YouCanGetById(id));
        }
        [HttpPost]
        public IActionResult UpdateDestination(Destination destination)
        {
            _destinationService.YouCanUpdate(destination);
            return RedirectToAction("Index");
        }
        [HttpGet("~/Admin/Destination/ChangeDestinationStatus/{id}/{destId}")]
        public IActionResult ChangeDestinationStatus(int id,int destId)
        {
            if (id == 1)
            {
                _destinationService.TSetTrueStatus(destId);
            }
            else
            {
                _destinationService.TSetFalseStatus(destId);
            }
            return RedirectToAction("Index");
        }
    }
}
