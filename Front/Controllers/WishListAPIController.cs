using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCModels.DataModels;
using Front.Service.WishList;
using Front.Models.DTOModels.WishList;
using MVCModels.APIModels;
using Microsoft.AspNetCore.Authorization;

namespace Front.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class WishListAPIController : ControllerBase
    {
        private readonly IWishListService _service;

        public WishListAPIController(IWishListService service)
        {
            _service = service;
        }


        // POST: api/WishList
        
        [HttpPost("Create")]       
        public WishListApiOutputDTO CreaateWishList([FromBody] int roomId)
        {
            var userEmail = User.Identity.Name;
            var inputDto = new WishListApiInputDTO() { UserEmail = userEmail, RoomId = roomId };
            var outputDto = _service.CreateWishList(inputDto);
            //var result = new WishListApiOutputDTO() { IsSuccess=true};
            return outputDto;
        }

        
        
        [HttpDelete("Delete")]
        public IActionResult DeleteWishList([FromBody] int roomId)
        {
            var userEmail = User.Identity.Name;
            var inputDto = new WishListApiInputDTO() { UserEmail = userEmail, RoomId = roomId };
            var outputDto = _service.DeleteWishList(inputDto);
            
            if(outputDto.IsSuccess == true)
            {
                return Ok(new BaseResult(true,APIStatus.Success,""));
            }
            else
            {
                return Ok(new BaseResult(true, APIStatus.Fail, ""));

            }
        }

        
    }
}
