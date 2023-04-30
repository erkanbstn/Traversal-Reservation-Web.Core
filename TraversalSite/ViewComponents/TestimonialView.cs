using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TraversalSite.ViewComponents
{
    public class TestimonialView : ViewComponent
    {
        TestimonialManager tm = new TestimonialManager(new EFTestimonialDal());
        public IViewComponentResult Invoke()
        {
            var testimonials = tm.YouCanList();
            return View(testimonials);
        }
    }
}
