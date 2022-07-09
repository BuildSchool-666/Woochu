using Front.Models.ViewModels.RoomDetails;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Front.Controllers
{
    public class RoomDetailsController : Controller
    {
        public IActionResult RoomDetails()
        {
            var vm = new RoomDetailsVM { 
                Title = "TEST_1",
                Rating = 4.9,
                Address = "TEST_2",
                ImgUrls = new List<string>
                {
                    "images/house-1.png",
                    "images/house-2.png",
                    "images/house-3.png",
                    "images/house-4.png",
                    "images/house-5.png",
                },
                RoomInfo = "TEST_3",
                BedCount = 1 ,
                BathCount = 1 ,
                RentPrice = 100,
                Discribtion = "oooxx",
                HostName = "james",
                JoinTime = 10,
                ReplyTime = 10,
            };
            return View(vm);
        }
    }
}
