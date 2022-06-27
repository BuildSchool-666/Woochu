using Microsoft.AspNetCore.Mvc;

namespace Front.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
