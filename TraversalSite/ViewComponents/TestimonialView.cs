using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TraversalSite.ViewComponents
{
    public class TestimonialView : ViewComponent
    {
        private readonly ITestimonialService _testimonialService;

        public TestimonialView(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        public IViewComponentResult Invoke()
        {
            var testimonials = _testimonialService.YouCanList();
            return View(testimonials);
        }
    }
}
