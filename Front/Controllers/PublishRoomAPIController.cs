using Front.Models.APIBase;
using Front.Models.ConfigModels;
using Front.Models.DTOModels.PublishRoom;
using Front.Models.ViewModels.PublishRoom;
using Front.Service.PublishRoom;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MVCModels.Enum;
using System;
using System.Collections.Generic;
using System.IO;

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

                return Ok(new APIResult(APIStatus.Success, string.Empty, true));
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
        //[HttpPut("Update/{result}")]
        //public IActionResult Update([FromRoute] string result, [FromBody] PublishRoomVM input)
        //{
        //    var a = (RoomPage)Enum.Parse(typeof(RoomPage), result);
        //    //if(a == RoomPage.amenities)
        //    //{
        //    //    _publishRoomService.GetAmenities()
        //    //}
        //    return Ok(new APIResult(APIStatus.Success, string.Empty, a));
        //}

        [HttpGet("GetFacility")]
        public IActionResult GetFacility()
        {
            try
            {
                var result = _publishRoomService.GetFacility();

                return Ok(new APIResult(APIStatus.Success, string.Empty, result));
            }
            catch (Exception ex)
            {
                return Ok(new APIResult(APIStatus.Fail, ex.Message, false));
            }
        }
        [HttpGet("GetCloudinary")]
        public IActionResult GetCloudinary()
        {
            var builder = new ConfigurationBuilder()
                  .SetBasePath(Directory.GetCurrentDirectory())
                  .AddJsonFile("appsettings.json");
            var config = builder.Build();
            try
            {
                var result = new CloudinaryJS()
                {
                    CLOUDINARY_URL = config["CloudinaryJS:CLOUDINARY_URL"],
                    CLOUDINARY_UPLOAD_PRESET = config["CloudinaryJS:CLOUDINARY_UPLOAD_PRESET"]
                };
                return Ok(new APIResult(APIStatus.Success, string.Empty, result));
            }
            catch (Exception ex)
            {
                return Ok(new APIResult(APIStatus.Fail, ex.Message, false));
            }
        }
    }
}
