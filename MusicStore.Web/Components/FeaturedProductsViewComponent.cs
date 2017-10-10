using Microsoft.AspNetCore.Mvc;

namespace MusicStore.Web.Components
{
    public class FeaturedProductsViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            ViewBag.HighLight = "Featured";
            ViewBag.Title = "Products";

            return View("_FeaturedProducts");
        }
    }
}
