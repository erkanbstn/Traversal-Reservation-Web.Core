using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace TraversalSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public IActionResult Index()
        {
            var values = _contactService.YouCanList();
            return View(values);
        }
        public IActionResult DeleteContact(int id)
        {
            _contactService.YouCanDelete(_contactService.YouCanGetById(id));
            return RedirectToAction("Index");
        }
        public IActionResult ContactDetail(int id)
        {
            return View(_contactService.YouCanGetById(id));
        }
    }
}
