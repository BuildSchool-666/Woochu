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
        //[HttpPost("GetRoomTypeParent")]
        //public IActionResult GetRoomTypeParent()
        //{
        //    try
        //    {
        //        var result = _publishRoomService.GetRoomTypeParent();
        //        return Ok(new APIResult(APIStatus.Success, string.Empty, result));
        //    }
        //    catch(Exception ex)
        //    {
        //        return Ok(new APIResult(APIStatus.Fail, ex.Message, null));
        //    }
        //}
        ////[HttpPost("GetRoomTypeParent/{RoomTypeParent}")]
        ////public IActionResult GetRoomTypeParent([FromRoute] int roomTypeParent)
        ////{
        ////    try
        ////    {
        ////        var result = _publishRoomService.GetRoomTypeParent();
        ////        return Ok(new APIResult(APIStatus.Success, string.Empty, result));
        ////    }
        ////    catch (Exception ex)
        ////    {
        ////        return Ok(new APIResult(APIStatus.Fail, ex.Message, null));
        ////    }
        ////}
        //[HttpPost("GetRoomType")]
        //public IActionResult GetRoomType([FromBody] int roomTypeId)
        //{
        //    try
        //    {
        //        var result = _publishRoomService.GetRoomType(roomTypeId);
        //        return Ok(new APIResult(APIStatus.Success, string.Empty, result));
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(new APIResult(APIStatus.Fail, ex.Message, null));
        //    }
        //}

        [HttpPost("Create/{roomTypeId}")]
        public IActionResult Create([FromRoute]int roomTypeId)
        {
            try
            {
                var userEmail = User.Identity.Name;
                _publishRoomService.CreateRoom(roomTypeId, userEmail);
                //List<string> roomPrivacy = new List<string>();
                //foreach(var i in Enum.GetNames(typeof(PrivacyType)))
                //{ roomPrivacy.Add(i); }
                return Ok(new APIResult(APIStatus.Success, string.Empty, roomTypeId));
            }
            catch (Exception ex)
            {
                return Ok(new APIResult(APIStatus.Fail, ex.Message, false));
            }
           
        }

        [HttpPut]
        public IActionResult Update(PublishRoomApiInputDTO input)
        {
            try
            {
                _publishRoomService.UpdateRoom(input);
                return Ok(new APIResult(APIStatus.Success, string.Empty, true));
            }
            catch (Exception ex)
            {
                return Ok(new APIResult(APIStatus.Fail, ex.Message, false));
            }

        }
}
}
