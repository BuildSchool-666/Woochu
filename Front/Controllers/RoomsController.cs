using Microsoft.AspNetCore.Mvc;

namespace Back.Controllers
{
    public class RoomsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult roomlist()
        {
            return View();
        }
        public IActionResult roomtype()
        {
            return View();
        }

    }
}
