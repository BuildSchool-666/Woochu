using Front.Models.DTOModels.RoomDetail;
using Front.Models.ViewModels.RoomDetails;
using Front.Service.RoomDetail;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Front.Controllers
{
    public class RoomDetailController : Controller
    {
        private readonly IRoomDetailService _service;

        public RoomDetailController(IRoomDetailService service)
        {
            _service = service;
        }
        [HttpGet("~/[controller]/[action]/{roomId}")]
        public IActionResult RoomDetail([FromRoute] int roomId)
        {
            var inputDto = new GetRoomsDetailInputDTO();

            inputDto.RoomId = roomId;


            var outputDto = _service.GetRoomsDetail(inputDto);
            //var vm = new RoomDetailsVM { 
            //    Title = "TEST_1",
            //    Rating = 4.9,
            //    Address = "TEST_2",
            //    ImgUrls = new List<string>
            //    {
            //        "images/house-1.png",
            //        "images/house-2.png",
            //        "images/house-3.png",
            //        "images/house-4.png",
            //        "images/house-5.png",
            //    },
            //    RoomInfo = "TEST_3",
            //    BedCount = 1 ,
            //    BathCount = 1 ,
            //    RentPrice = 100,
            //    Discribtion = "oooxx",
            //    HostName = "james",
            //    JoinTime = 10,
            //    ReplyTime = 10,
            //};
            if (!outputDto.IsSuccess)
            {
                return Redirect("/");
                //return RedirectToAction("Index","Home");
            }
            return View(outputDto.VM);
        }
    }
}
