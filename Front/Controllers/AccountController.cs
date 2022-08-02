using Front.Models.DTOModels.Account;
using Front.Models.ViewModels.Account;
using Front.Service.Accounts;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace Front.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _service;

        public AccountController(IAccountService service)
        {
            _service = service;
        }

        public IActionResult Register()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Register([FromForm] RegisterVM requestParam)
        {
            if (!ModelState.IsValid)
            {
                return View(requestParam);
            }

            var inputDto = new CreateAccountInputDTO
            {
                Email = requestParam.Email,
                Password = requestParam.Password,
                PasswordConfirm = requestParam.PasswordConfirm
            };
            var outputDto = _service.CreateAccount(inputDto);
            ViewData["message"] = outputDto.Message;

            if (!outputDto.IsSuccess)
            {
                ModelState.AddModelError(string.Empty, outputDto.Message);
                return View(requestParam);
            }

            var vm = new GoCheckEmailVM();
            return View("GoCheckEmail", vm);
        }
        public IActionResult Verify([FromQuery] int VIP_NO)
        {
            _service.VerifyAccount(VIP_NO);
            return View();
        }
        public IActionResult Login(string returnUrl = null )
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login([FromForm] LoginVM requestParam, string returnUrl = null)
        {
            if (!ModelState.IsValid)
            {
                return View(requestParam);
            }
            var inputDto = new LoginAccountInputDTO
            {
                Email = requestParam.Email,
                Password = requestParam.Password
            };
            //var user = new IdentityUser { UserName = Input.Email, Email = Input.Email };
            var outputDto = _service.LoginAccount(inputDto);
            ViewData["message"] = outputDto.Message;
            if (!outputDto.IsSuccess)
            {
                ModelState.AddModelError(string.Empty, outputDto.Message);
                return View(requestParam);

            }

            return Redirect(returnUrl ?? "/");
        }
        public IActionResult LogOut()
        {
            _service.LogoutAccount();
            return Redirect("/");
        }
    }
}
