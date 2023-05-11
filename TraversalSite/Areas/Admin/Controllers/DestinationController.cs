using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TraversalSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DestinationController : Controller
    {
        DestinationManager dm = new DestinationManager(new EFDestinationDal());
        public IActionResult Index()
        {
            var values = dm.YouCanList();
            return View(values);
        }
        public IActionResult AddDestination()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddDestination(Destination destination)
        {
            dm.YouCanInsert(destination);
            return RedirectToAction("Index");
        }
        public IActionResult UpdateDestination(int id)
        {
            return View(dm.YouCanGetById(id));
        }
        [HttpPost]
        public IActionResult UpdateDestination(Destination destination)
        {
            dm.YouCanUpdate(destination);
            return RedirectToAction("Index");
        }
        [HttpGet("~/Admin/Destination/ChangeDestinationStatus/{id}/{destId}")]
        public IActionResult ChangeDestinationStatus(int id,int destId)
        {
            if (id == 1)
            {
               dm.TSetTrueStatus(destId);
            }
            else
            {
                dm.TSetFalseStatus(destId);
            }
            return RedirectToAction("Index");
        }
    }
}
