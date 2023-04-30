using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TraversalSite.ViewComponents
{
    public class FeatureView : ViewComponent
    {
        FeatureManager fm = new FeatureManager(new EFFeatureDal());
        public IViewComponentResult Invoke()
        {
            var features = fm.YouCanList();
            return View(features);
        }

    }
}
