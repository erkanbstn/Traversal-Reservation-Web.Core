using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TraversalSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GuideController : Controller
    {
        private readonly IGuideService _guideService;
        private readonly ILogger<GuideController> _logger;

        public GuideController(IGuideService guideService, ILogger<GuideController> logger)
        {
            _guideService = guideService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            //_logger.LogInformation("Rehber Listesi Görüntülendi");
            var values = _guideService.YouCanList();
            return View(values);
        }
        public IActionResult DeleteGuide(int id)
        {
            _guideService.YouCanDelete(_guideService.YouCanGetById(id));
            return RedirectToAction("Index");
        }
        public IActionResult UpdateGuide(int id)
        {
            return View(_guideService.YouCanGetById(id));
        }
        [HttpPost]
        public IActionResult UpdateGuide(Guide guide)
        {
            _guideService.YouCanUpdate(guide);
            return RedirectToAction("Index");
        }
        public IActionResult AddGuide()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddGuide(Guide guide)
        {
            _guideService.YouCanInsert(guide);
            return RedirectToAction("Index");
        }
    }
}
