using Front.Models.DTOModels.Order;
using Front.Models.ViewModels.Order;
using Front.Service.Order;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Front.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _service;

        public OrderController( IOrderService service)
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult BankAccount([FromRoute] int roomId)
        {
            var inputDto = new GetorderDetailInputDTO();

            inputDto.RoomId = roomId;

            var outputDto = _service.GetOrderData(inputDto);


            if (!outputDto.IsSuccess)
            {
                return Redirect("/");
                //return RedirectToAction("Index","Home");
            }
            return View(outputDto.VM);
        }
        //[HttpPost]
        [HttpPost("~/[controller]/[action]/{roomId}")]
        public IActionResult BankAccount([FromForm] OrderFilterForm requestParam, [FromRoute] int roomId)
        {
            var inputDto = new GetorderDetailInputDTO()
            {
                RoomId = roomId,
                CheckinTime = requestParam.CheckinTime,
                CheckoutTime = requestParam.CheckoutTime,
            };
            var outputDto = _service.GetOrderData(inputDto);

            return View(outputDto.VM);
        }

    }
}
