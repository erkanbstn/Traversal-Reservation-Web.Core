using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TraversalSite.Areas.Member.Controllers
{
    [Area("Member")]
    [AllowAnonymous]
    public class ReservationController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public ReservationController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        DestinationManager dm = new DestinationManager(new EFDestinationDal());
        ReservationManager rm = new ReservationManager(new EFReservationDal());
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var reservations = rm.TGetListByUsers(user.Id);
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
        public async Task<IActionResult> NewReservation(Reservation r)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            r.AppUserId = user.Id;
            r.Status = "Onay Bekliyor."; // Müşteri İptal Etti, Onaylandı, Kontenjan Dolu
            rm.YouCanInsert(r);
            return RedirectToAction("Index");
        }
    }
}
