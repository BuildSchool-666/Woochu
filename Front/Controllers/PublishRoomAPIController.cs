using Front.Models.APIBase;
using Front.Models.DTOModels.PublishRoom;
using Front.Models.ViewModels.PublishRoom;
using Front.Service.PublishRoom;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCModels.Enum;
using System;
using System.Collections.Generic;

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

        [HttpGet("GetRoomTypeParent")]
        public IActionResult GetRoomTypeParent()
        {
            try
            {
                var result = _publishRoomService.GetRoomTypeParent();
                return Ok(new APIResult(APIStatus.Success, string.Empty, result));
            }
            catch (Exception ex)
            {
                return Ok(new APIResult(APIStatus.Fail, ex.Message, null));
            }
        }
        [HttpPost("GetRoomTypeParent/{RoomTypeParent}")]
        public IActionResult GetRoomTypeParent([FromRoute] int roomTypeParent)
        {
            try
            {
                var result = _publishRoomService.GetRoomTypeParent();
                return Ok(new APIResult(APIStatus.Success, string.Empty, result));
            }
            catch (Exception ex)
            {
                return Ok(new APIResult(APIStatus.Fail, ex.Message, null));
            }
        }

        ///<summary>
        ///一轉到二頁
        ///</summary>
        ///<param name = "input" ></ param >
        ///< returns ></ returns >
        [HttpGet("GetRoomType/{roomTypeGroupId}")]
        public IActionResult GetRoomType([FromRoute] int roomTypeGroupId)
        {
            try
            {
                var result = _publishRoomService.GetRoomType(roomTypeGroupId);
                return Ok(new APIResult(APIStatus.Success, string.Empty, result));
            }
            catch (Exception ex)
            {
                return Ok(new APIResult(APIStatus.Fail, ex.Message, null));
            }
        }

        /// <summary>
        ///二頁創建房源
        /// </summary>
        /// <param name="result"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("Create")]
        public IActionResult Create(PublishRoomApiInputDTO input)
        {
            try
            {
                var userEmail = User.Identity.Name;
                _publishRoomService.CreateRoom(input);

                List<string> roomPrivacy = new List<string>();
                foreach (var i in Enum.GetNames(typeof(PrivacyType)))
                { roomPrivacy.Add(i); }

                return Ok(new APIResult(APIStatus.Success, string.Empty, roomPrivacy));
            }
            catch (Exception ex)
            {
                return Ok(new APIResult(APIStatus.Fail, ex.Message, false));
            }
        }
        
        /// <summary>
        /// 後十幾頁的資料update
        /// </summary>
        /// <param name="result"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPut("Update/{result}")]
        public IActionResult Update([FromRoute] string result, [FromBody] PublishRoomVM input)
        {
            var a = (RoomPage)Enum.Parse(typeof(RoomPage), result);
            //if(a == RoomPage.amenities)
            //{
            //    _publishRoomService.GetAmenities()
            //}
            return Ok(new APIResult(APIStatus.Success, string.Empty, a));
        }
        
    }
}
