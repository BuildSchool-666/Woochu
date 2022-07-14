using Front.Models.ViewModels.Order;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Front.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult bankAccount()
        {

            var date = new DateTime(2021, 10, 03);
            string dt = date.ToShortDateString();
            var date2 = new DateTime(2022, 10, 03);
            string dt2 = date2.ToShortDateString();

            int Oprice = 200 * 365;
            int Tprice = 200 * 365 + 70;


            OrderVM order = new OrderVM
            {
                ImgUrll = "https://picsum.photos/300/200/?random=11",
                ImgUrl2 = "https://picsum.photos/300/200/?random=12",
                ImgUrl3 = "https://picsum.photos/300/200/?random=13",
                ImgUrl4 = "https://picsum.photos/300/200/?random=14",
                ImgUrl5 = "https://picsum.photos/300/200/?random=15",
                Title = "Taiwan 101",
                RoomInfo = "The Highest Building In The World",
                BedCount = 2,
                BathCount = 4,
                RatingScore = 4.5,
                RentPrice = 200,
                StarDate = dt,
                endDate = dt2,
                DateRange = date2.Subtract(date).Days,
                OrderPrice = Oprice,
                ServiceFee = 70,
                TotalPrice = Tprice,

            };

            return View(order);
        }
    }
}
