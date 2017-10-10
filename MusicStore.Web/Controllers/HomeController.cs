using Microsoft.AspNetCore.Mvc;

namespace MusicStore.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
