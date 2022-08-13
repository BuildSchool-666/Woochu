using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Front.Controllers
{
    public class BecomeHostController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult property_type_group()
        {
            return View();
        }

        public IActionResult property_type()
        {
            return View();
        }

        public IActionResult privacy_type()
        {
            return View();
        }

        public IActionResult location()
        {
            return View();
        }

        public IActionResult location2()
        {
            return View();
        }

        public IActionResult floor_plan()
        {
            return View();
        }

        public IActionResult amenities()
        {
            return View();
        }

        public IActionResult photo()
        {
            return View();
        }

        public IActionResult title()
        {
            return View();
        }

        public IActionResult description()
        {
            return View();
        }

        public IActionResult price()
        {
            return View();
        }
        public IActionResult legal()
        {
            return View();
        }

        public IActionResult preview()
        {
            return View();
        }
    }
}
