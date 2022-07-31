using Front.Models.DTOModels.Rooms;
using Front.Models.ViewModels.Rooms;
using Front.Service.Rooms;
using Microsoft.AspNetCore.Mvc;
using MVCModels.MyEnum;
using System;
using System.Collections.Generic;
using System.Dynamic;

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
        //city search
        public IActionResult Roomlist([FromRoute]string city)
        {
            var inputDto = new GetRoomsCardInputDTO();
            if (city == null)
            {
                inputDto.City = 0;
            }
            else
            {
                inputDto.City = (City)Enum.Parse(typeof(City), city);
            }

            var getRoomsCardOutputDto = _service.GetRoomsCard(inputDto);
            var getFacilityOutputDto = _service.GetFacility();
            var getRoomTypeOutputDto = _service.GetRoomType();
            dynamic vm = new ExpandoObject();
            vm.RoomsCard = getRoomsCardOutputDto.VM;
            vm.Facility = getFacilityOutputDto;
            vm.RoomType = getRoomTypeOutputDto;
            return View(vm);
        }
        [HttpPost]
        //search form
        public IActionResult Roomlist([FromForm] RoomFilterForm requestParam)
        {
            
            var inputDto = new GetRoomsCardInputDTO()
            {
                City = requestParam.City,
                CheckinTime = requestParam.CheckinTime,
                CheckoutTime = requestParam.CheckoutTime,
                
            };
            var outputDto = _service.GetRoomsCard(inputDto);

            return View(outputDto.VM);
        }
        //public IActionResult roomlistPage2()
        //{
        //    return View();
        //}
        //public IActionResult roomlistPage3()
        //{
        //    return View();
        //}
        //public IActionResult roomtype()
        //{
        //    return View();
        //}

    }
}
