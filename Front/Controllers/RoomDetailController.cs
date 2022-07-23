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
            
            if (!outputDto.IsSuccess)
            {
                return Redirect("/");
                //return RedirectToAction("Index","Home");
            }
            return View(outputDto.VM);
        }
    }
}
