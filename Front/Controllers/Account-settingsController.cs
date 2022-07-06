using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCModels.DataModels;
using MVCModels.Repositories;
using System;
using System.Linq;

namespace Front.Controllers
{
    public class Account_settingsController : Controller
    {
        private readonly WoochuContext _context;
        public Account_settingsController(WoochuContext context)
        {
            _context = context;
        }

        public IActionResult Index(int id)
        {
            var query = _context.Users.Where(u => u.UserId == 1).FirstOrDefault();
            User user = new User
            {
                UserId = query.UserId,
                FirstName = query.FirstName,
                LastName = query.LastName,
                Email = query.Email,
            };
            return View(user);
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
