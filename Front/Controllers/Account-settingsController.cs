using Microsoft.AspNetCore.Mvc;

namespace Front.Controllers
{
    public class Account_settingsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult PersonalInformation()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult GlobalPreference()
        {
            return View();
        }
        public IActionResult GuesrReferrals()
        {
            return View();
        }
        public IActionResult ProfessionalHostTools()
        {
            return View();
        }

    }
}
