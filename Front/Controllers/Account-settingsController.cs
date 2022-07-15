using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCModels.DataModels;
using MVCModels.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Security.Principal;
using Front.Models.ViewModels.Account_settings;

namespace Front.Controllers
{
    public class Account_settingsController : Controller
    {
        private readonly WoochuContext _context;
        public Account_settingsController(WoochuContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {

            //var users = User.Identity.Name;
            //int use = int.Parse(users);

            //var query = _context.Users.Where(u => u.UserId == use).FirstOrDefault();

            //User user = new User
            //{
            //    UserId = query.UserId,
            //    FirstName = query.FirstName,
            //    LastName = query.LastName,
            //    Email = query.Email,
            //};
            var userid = int.Parse(User.Identity.Name);
            var user = await _context.Users.FindAsync(userid);
            return View(user);

        }
        [HttpGet]
        public async Task<IActionResult> PersonalInformation()
        {
            var userid = int.Parse(User.Identity.Name); 
            var user = await _context.Users.FindAsync(userid);
            
            return View(user);

        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult PersonalInformation(User user)
        {

            int userId = int.Parse(User.Identity.Name);
            //int user = userId);

            var query = _context.Users.SingleOrDefault(u => u.UserId == userId);
            query.FirstName = user.FirstName;
            query.LastName = user.LastName;
            //User member = new User
            //{
            //    UserId = query.UserId,
            //    FirstName = query.FirstName,
            //    LastName = query.LastName,
            //    Email = query.Email,
            //};
            //_context.Add(member).State = EntityState.Modified;
            _context.SaveChanges();

            return View(query);

        //    if (ModelState.IsValid)
        //    {
        //        _context.Entry(user).State = EntityState.Modified;
        //        _context.SaveChanges();

        //    }
        ////    return View(user);
        //if (ModelState.IsValid)
        //{
        //    _context.Users.Add(user);
        //    _context.SaveChanges();
        //    return Content("储存成功");
        //}
        
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
