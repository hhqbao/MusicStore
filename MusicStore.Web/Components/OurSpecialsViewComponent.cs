using Microsoft.AspNetCore.Mvc;

namespace MusicStore.Web.Components
{
    public class OurSpecialsViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            ViewBag.HighLight = "Our";
            ViewBag.Title = "Specials";

            return View("_OurSpecials");
        }
    }
}
