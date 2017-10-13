using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MusicStore.Web.Controllers
{
    [Authorize]
    public class PersonalController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.ClassHidden = "hidden";

            return View();
        }
    }
}