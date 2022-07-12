using Front.Models.DTOModels.Rooms;
using Front.Models.ViewModels.Rooms;
using Front.Service.Rooms;
using Microsoft.AspNetCore.Mvc;
using MVCModels.MyEnum;
using System;
using System.Collections.Generic;

namespace Back.Controllers
{
    public class RoomsController : Controller
    {
        private readonly IRoomsService _service;

        public RoomsController(IRoomsService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("~/[controller]/[action]/{city?}")]
        public IActionResult Roomlist([FromRoute]string city)
        {
            var outputDto = new GetRoomsCardInputDTO
            {
                City = city,

            }
            var vm = 
            //new RoomlistVM
            //{
            //    City = "City",
            //    Rooms = new List<RoomVM>
            //    {
            //        new RoomVM
            //        {
            //            ImgUrl = "https://picsum.photos/300/200/?random=10",
            //            Title = "ooxx",
            //            HouseInfo = " idiot",
            //            BedCount = 1,
            //            BathCount = 1,
            //            Rating = 4.3,
            //            RentPrice = 200,
            //        },
            //    },
            //};
            var outputDto = _service.GetRoomsCard(inputDto);

            return View(vm);
        }
        public IActionResult roomlistPage2()
        {
            return View();
        }
        public IActionResult roomlistPage3()
        {
            return View();
        }
        public IActionResult roomtype()
        {
            return View();
        }

    }
}
