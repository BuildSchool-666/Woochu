using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Front.Models.DTOModels.Payment;
using Front.Models.ViewModels.Order;
using Front.Models.ViewModels.Payment;
using Front.Service.Payment;
using Front.Service.Payment.Enums;
using Front.Service.Payment.Service;
using Microsoft.AspNetCore.Mvc;

namespace Front.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PaymentController : Controller
    {
        private readonly IPaymentService _service;
        public PaymentController(IPaymentService service)
        {
            _service = service;
        }


        [HttpPost("/[controller]/checkout/{roomId}")]
        public IActionResult CheckOut([FromRoute]int roomId)
        {
            var getRoomOutputDto = _service.GetRoom(roomId);

            var service = new
            {
                Url = "https://payment-stage.ecpay.com.tw/Cashier/AioCheckOut/V5",
                MerchantId = "2000132",
                HashKey = "5294y06JbISpM5x9",
                HashIV = "v77hoKGq4kWxNNIS",
                ServerUrl = "https://fb80-220-141-64-30.jp.ngrok.io/Payment/callback", 
                ClientUrl = "https://fb80-220-141-64-30.jp.ngrok.io/"
            };
            var transaction = new
            {
                No = "Woochu",
                Description = "Woochu Desciption",
                Date = (DateTimeOffset.Now - DateTimeOffset.Now.Offset).AddHours(8).DateTime,
                Method = EPaymentMethod.Credit,
                Items = new List<Item>{
                    new Item{
                        Name = getRoomOutputDto.VM.Title,
                        Price = (int)TempData["BasicPrice"],
                        ServiceCharge = (int)TempData["ServiceFee"],
                        Quantity = (int)TempData["DateRange"],
                    },
                }
            };
            IPayment payment = new PaymentConfiguration()
                .Send.ToApi(
                    url: service.Url)
                .Send.ToMerchant(
                    service.MerchantId)
                .Send.UsingHash(
                    key: service.HashKey,
                    iv: service.HashIV)
                .Return.ToServer(
                    url: service.ServerUrl)
                .Return.ToClient(
                    url: service.ClientUrl)
                .Transaction.New(
                    no: transaction.No,
                    description: transaction.Description,
                    date: transaction.Date)
                .Transaction.UseMethod(
                    method: transaction.Method)
                .Transaction.WithItems(
                    items: transaction.Items)
                .Generate();

            var getUserOutputDto = _service.GetUser(User.Identity.Name);

            var inputDto = new CreateOrderInputDTO()        //use api post
            {
                OrderId = payment.MerchantTradeNo,
                RoomId = (int)TempData["RoomId"],
                CustomerId = (int)TempData["CustomerId"],
                OrderDate = (DateTimeOffset.Now - DateTimeOffset.Now.Offset).AddHours(8),
                CheckinTime = (DateTime)TempData["StartDate"],
                CheckoutTime = (DateTime)TempData["EndDate"],
                BasicPrice = (int)TempData["BasicPrice"],
                Quantity = (int)TempData["DateRange"],
                ServiceFee = (int)TempData["ServiceFee"],
                TotalPrice = (int)TempData["TotalPrice"],
            };
            var result = _service.CreateOrder(inputDto);
            if (result.IsSuccess != true)
            {
            }

            return View(payment);
        }

        [HttpPost("callback")]
        [Consumes("application/x-www-form-urlencoded")]
        public IActionResult Callback([FromForm] PaymentResult paymentresult)
        {
            var hashKey = "5294y06JbISpM5x9";
            var hashIV = "v77hoKGq4kWxNNIS";

            // 務必判斷檢查碼是否正確。
            if (!CheckMac.PaymentResultIsValid(paymentresult, hashKey, hashIV)) return BadRequest();

            // 處理後續訂單狀態的更動等等...。
            var result = _service.UpdatePayedStatus(paymentresult.MerchantTradeNo);
            if(result.IsSuccess != true)
            {

            }

            return Ok("1|OK");
        }
    }
}