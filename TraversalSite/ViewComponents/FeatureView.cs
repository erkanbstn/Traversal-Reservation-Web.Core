using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TraversalSite.ViewComponents
{
    public class FeatureView : ViewComponent
    {
        private readonly IFeatureService _featureService;

        public FeatureView(IFeatureService featureService)
        {
            _featureService = featureService;
        }

        public IViewComponentResult Invoke()
        {
            var features = _featureService.YouCanList();
            return View(features);
        }

    }
}
