using Front.Models.APIBase;
using Front.Models.DTOModels.PublishRoom;
using Front.Service.PublishRoom;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Front.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishRoomAPIController : ControllerBase
    {
        private readonly IPublishRoomService _publishRoomService;

        public PublishRoomAPIController(IPublishRoomService publishRoomService)
        {
            _publishRoomService = publishRoomService;
        }
        [HttpGet("GetRoomType")]
        public IActionResult GetRoomTypeParent()
        {
            try
            {
                var result = _publishRoomService.GetRoomType();
                return Ok(new APIResult(APIStatus.Success, string.Empty, result));
            }
            catch(Exception ex)
            {
                return Ok(new APIResult(APIStatus.Fail, ex.Message, null));
            }
        }
        [HttpGet("GetRoomType")]
        public IActionResult GetRoomType()
        {
            try
            {
                var result = _publishRoomService.GetRoomType();
                return Ok(new APIResult(APIStatus.Success, string.Empty, result));
            }
            catch (Exception ex)
            {
                return Ok(new APIResult(APIStatus.Fail, ex.Message, null));
            }
        }

        [HttpPost("Create")]
        public PublishRoomApiOutputDTO Create([FromBody] int roomtypeId)
        {
            var userEmail = User.Identity.Name;
            var inputDto = new PublishRoomApiInputDTO()
            {
                UserEmail = userEmail,
                RoomTypeId = roomtypeId,

            };
            var outputDto = _publishRoomService.CreateRoom(inputDto);
            return outputDto;
        }
    }
}
