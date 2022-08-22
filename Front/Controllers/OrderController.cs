using Front.Models.DTOModels.Order;
using Front.Models.ViewModels.Order;
using Front.Service.Order;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Front.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderService _service;

        public OrderController( IOrderService service)
        {
            _service = service;
        }

        [HttpPost("~/[controller]/[action]/{roomId}")]
        public IActionResult BankAccount([FromForm] OrderFilterForm requestParam, [FromRoute] int roomId)
        {

            var inputDto = new GetorderDetailInputDTO()
            {
                RoomId = roomId,
                CustomerMail = User.Identity.Name,
                CheckinTime = requestParam.CheckinTime,
                CheckoutTime = requestParam.CheckoutTime,
            };
            var outputDto =  _service.GetOrderData(inputDto);
            var orderData = new OrderVM
            {
                RoomId = roomId,
                CustomerId = outputDto.VM.CustomerId,
                StartDate = requestParam.CheckinTime,
                EndDate = requestParam.CheckoutTime,
                BasicPrice = outputDto.VM.BasicPrice,
                DateRange = outputDto.VM.DateRange,
                ServiceFee = outputDto.VM.ServiceFee,
                TotalPrice = outputDto.VM.TotalPrice,
            };

            TempData["RoomId"] = orderData.RoomId;
            TempData["CustomerId"] = orderData.CustomerId;
            TempData["StartDate"] = orderData.StartDate;
            TempData["EndDate"] = orderData.EndDate;
            TempData["BasicPrice"] = orderData.BasicPrice;
            TempData["DateRange"] = orderData.DateRange;
            TempData["ServiceFee"] = orderData.ServiceFee;
            TempData["TotalPrice"] = orderData.TotalPrice;
            TempData.Keep();

            return View(outputDto.VM);
        }

    }
    
}
