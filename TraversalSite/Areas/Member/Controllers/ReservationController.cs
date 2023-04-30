using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace TraversalSite.Areas.Member.Controllers
{
    [Area("Member")]
    [AllowAnonymous]
    public class ReservationController : Controller
    {
        DestinationManager dm = new DestinationManager(new EFDestinationDal());
        ReservationManager rm = new ReservationManager(new EFReservationDal());
        public IActionResult Index()
        {
            var reservations= rm.YouCanList();
            return View(reservations);
        }
        public IActionResult NewReservation()
        {
            List<SelectListItem> values = (from x in dm.YouCanList()
                                           select new SelectListItem
                                           {
                                               Text = x.City,
                                               Value = x.DestinationId.ToString()
                                           }).ToList();

            ViewBag.rotalar = values;
            return View();
        }
        [HttpPost]
        public IActionResult NewReservation(Reservation r)
        {
            rm.YouCanInsert(r);
            return RedirectToAction("Index");
        }
    }
}
