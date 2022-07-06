using Microsoft.AspNetCore.Mvc;
//using MVCModels.DataModels;
using MVCModels.Repositories;
using System.Linq;

namespace Front.Controllers
{
    public class LoginController : Controller
    {
        private readonly WoochuRepository repo;

        public LoginController()
        {
            //repo = new WoochuRepository(new WoochuContext());
        }
        public IActionResult Index(int? y)
        {
            return View();
        }
    }
}
