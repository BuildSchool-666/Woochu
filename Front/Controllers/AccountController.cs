using Front.Models.DTOModels;
using Front.Models.ViewModels.Account;
using Front.Service.Account;
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
        public IActionResult Register(RegisterVM requestParam)
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
        public IActionResult Login()
        {
            return View();
        }
    }
}
