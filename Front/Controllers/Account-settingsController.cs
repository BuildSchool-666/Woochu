using Microsoft.AspNetCore.Mvc;
using MVCModels.DataModels;
using System.Linq;
using System.Threading.Tasks;
using Front.Models.DTOModels.Account_setting_DTO;
using Front.Service.Account_setting;
using Front.Models.ViewModels.Account_settings;

namespace Front.Controllers
{
    public class Account_settingsController : Controller
    {
        private readonly IAccount_settingService _service;
        private readonly WoochuContext _context;
        public Account_settingsController(WoochuContext context, IAccount_settingService service)
        {
            _context = context;
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var inputDto = new PersonalDetailsInputDTO();

            inputDto.Email = User.Identity.Name;

            var outputDto = _service.GetUserData(inputDto);

            if (!outputDto.IsSuccess)
            {
                return Redirect("/");

            }
            return View(outputDto.VM);

            //var userid = int.Parse(User.Identity.Name);
            //var user = await _context.Users.FindAsync(userid);
            //return View(user);

        }
        [HttpGet]
        public async Task<IActionResult> PersonalInformation()
        {
            var inputDto = new PersonalDetailsInputDTO();

            inputDto.Email = User.Identity.Name;


            var outputDto = _service.GetUserData(inputDto);

            if (!outputDto.IsSuccess)
            {
                return Redirect("/");

            }
            return View(outputDto.VM);
            //var userid = int.Parse(User.Identity.Name);
            //var user = await _context.Users.FindAsync(userid);

            //return View(user);

        }

        [HttpPost]
        public IActionResult PersonalInformation([FromForm] PersonalInformationVM requestParam)
        {
            if (!ModelState.IsValid)
            {
                return View(requestParam);
            }
            var inputDto = new PersonalDetailsInputDTO()
            {
                Email = User.Identity.Name,
                VM = new PersonalInformationVM
                {
                    FirstName = requestParam.FirstName,
                    LastName = requestParam.LastName,
                    Email = requestParam.Email,
                    Gender = requestParam.Gender,
                    Dob = requestParam.Dob,
                    Phone = requestParam.Phone,
                    EmergencyContactName = requestParam.EmergencyContactName,
                    EmergencyContactNumber = requestParam.EmergencyContactNumber,
                    Address = requestParam.Address,

                }

            };
            var outputDto = _service.UpdateUserData(inputDto);

            if (!outputDto.IsSuccess)
            {
                ModelState.AddModelError(string.Empty, outputDto.Message);
                return View(requestParam);
            }
            return View(outputDto.VM);
        }
        //[ValidateAntiForgeryToken]
        //public IActionResult PersonalInformation(User user)
        //{

        //    int userId = int.Parse(User.Identity.Name);

        //    var query = _context.Users.SingleOrDefault(u => u.UserId == userId);
        //    query.FirstName = user.FirstName;
        //    query.LastName = user.LastName;
        //    query.Gender = user.Gender;

        //    _context.SaveChanges();

        //    return View(query);

        //}

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult GlobalPreference()
        {
            return View();
        }
        public IActionResult GuestReferrals()
        {
            return View();
        }
        public IActionResult ProfessionalHostTools()
        {
            return View();
        }
        public IActionResult Notification()
        {
            return View();
        }
        public IActionResult TravelForWork()
        {
            return View();
        }

    }
}
