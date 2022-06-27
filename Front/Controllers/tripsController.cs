using Microsoft.AspNetCore.Mvc;

namespace Front.Controllers
{
    public class tripsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
