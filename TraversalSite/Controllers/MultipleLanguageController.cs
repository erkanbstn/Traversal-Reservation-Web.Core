using Microsoft.AspNetCore.Mvc;

namespace TraversalSite.Controllers
{
    public class MultipleLanguageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
