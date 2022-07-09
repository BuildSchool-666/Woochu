using Microsoft.AspNetCore.Mvc;

namespace Back.Controllers
{
    public class RoomsController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
        [Route("~/[controller]/[action]/{City}")]
        public IActionResult roomlist([FromRoute]string City)
        {

            return View();
        }
        public IActionResult roomlistPage2()
        {
            return View();
        }
        public IActionResult roomlistPage3()
        {
            return View();
        }
        public IActionResult roomtype()
        {
            return View();
        }

    }
}
