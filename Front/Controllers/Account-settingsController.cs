using Microsoft.AspNetCore.Mvc;
using MVCModels.DataModels;
using System.Linq;
using System.Threading.Tasks;
using Front.Models.DTOModels.Account_setting_DTO;
using Front.Service.Account_setting;
using Front.Models.ViewModels.Account_settings;
using System.Configuration;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using System.Text.RegularExpressions;
using System.Drawing;
using System.IO;
using Microsoft.AspNetCore.Http;
using Front.Models.DTOModels.Cloudinary;
using Front.Service.Cloudinarys;

namespace Front.Controllers
{
    public class Account_settingsController : Controller
    {
        private readonly IAccount_settingService _service;
        private readonly WoochuContext _context;
        private readonly CloudinaryService _cloudinaryService;

        public Account_settingsController(WoochuContext context, IAccount_settingService service,CloudinaryService cloudinaryService)
        {
            _context = context;
            _service = service;
            _cloudinaryService = cloudinaryService;
            
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
        public async Task<IActionResult> Profile()
        {
            var inputDto = new PersonalDetailsInputDTO();

            inputDto.Email = User.Identity.Name;


            var outputDto = _service.GetUserData(inputDto);

            if (!outputDto.IsSuccess)
            {
                return Redirect("/");

            }
            return View(outputDto.VM);
        }

        [HttpPost]
        public async Task<IActionResult> Profile([FromForm] IFormFile File)
        {
            var inputDto = new UploadImgInputDTO()
            {
                File = File
            };
            var outputDTO = await _cloudinaryService.UploadAsync(inputDto);

            var input = new PersonalDetailsInputDTO()
            {
                Email = User.Identity.Name,
                VM = new PersonalInformationVM
                {
                    PersonalPhoto = outputDTO.Url
                }
            };

            var output = _service.UpdateProfilePhoto(input);

            if (!output.IsSuccess)
            {
                ModelState.AddModelError(string.Empty, output.Message);
                return View(output);
            }
            return View(output.VM);

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
