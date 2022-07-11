using Front.Models.DTOModels.Rooms;
using Front.Models.ViewModels.Rooms;
using Front.Service.Rooms;
using Microsoft.AspNetCore.Mvc;
using MVCModels.MyEnum;
using System;

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
            var inputDto = new GetRoomsCardInputDTO();
            if(city == null)
            {
                inputDto.City = 0;
            }
            else
            {
                inputDto.City = (City)Enum.Parse(typeof(City), city);
            }
            
            var outputDto = _service.GetRoomsCard(inputDto);

            //if (!outputDto.IsSuccess)
            //{
            //}

            return View(outputDto.VM);
        }
        [HttpPost]
        public IActionResult Roomlist([FromForm] RoomFilterForm requestParam)
        {
            //var vm = new RoomlistVM
            //{
            //    city = "Taiwan",
            //    imgUrl = "https://picsum.photos/300/200/?random=10",
            //    title = "ooxx",
            //    HouseInfo = " idiot",
            //    BedCount = 1,
            //    BathCount = 1,
            //    rating = 4.3,
            //    RentPrice = 200,
            //};
            var inputDto = new GetRoomsCardInputDTO() { 
                City = requestParam.City,
                CheckinTime = requestParam.CheckinTime,
                CheckoutTime = requestParam.CheckoutTime,
                Person = requestParam.Person,
            };
            var outputDto = _service.GetRoomsCard(inputDto);

            return View(outputDto.VM);
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
