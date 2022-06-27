using Microsoft.AspNetCore.Mvc;

namespace Front.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
