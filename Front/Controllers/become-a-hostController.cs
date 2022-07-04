using Microsoft.AspNetCore.Mvc;

namespace Front.Controllers
{
    public class HostController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Intro()
        {
            return View();
        }
    }
}
