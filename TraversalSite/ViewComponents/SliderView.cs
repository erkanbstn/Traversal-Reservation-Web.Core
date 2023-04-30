using Microsoft.AspNetCore.Mvc;

namespace TraversalSite.ViewComponents
{
    public class SliderView : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
