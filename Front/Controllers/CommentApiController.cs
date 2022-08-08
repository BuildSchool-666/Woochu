using CloudinaryDotNet.Actions;
using Front.Models.DTOModels;
using Front.Service.Comment;
using Microsoft.AspNetCore.Mvc;
using MVCModels.APIModels;
using System.Collections.Generic;
using BaseResult = MVCModels.APIModels.BaseResult;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Front.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentApiController : ControllerBase
    {
        private readonly ICommentService _service;

        public CommentApiController(ICommentService service)
        {
            _service = service;
        }
        

        // POST api/<CommentApiController>
        [HttpPost("Create")]
        public CommentApiOutputDTO CreateComment([FromBody] int roomId)
        {
            var userEmail = User.Identity.Name;
            var inputDto = new CommentApiInputDTO() { Email = userEmail, RoomId = roomId };
            var outputDto = _service.CreateComment(inputDto);
            
            return outputDto;
        }

        

        // DELETE api/<CommentApiController>/5
        [HttpDelete("Delete")]
        public IActionResult DeleteComment([FromBody] int roomId)
        {
            var userEmail = User.Identity.Name;
            var inputDto = new CommentApiInputDTO() { Email = userEmail, RoomId = roomId };
            var outputDto = _service.DeleteComment(inputDto);

            if (outputDto.IsSuccess == true)
            {
                return Ok(new BaseResult(true, APIStatus.Success, ""));
            }
            else
            {
                return Ok(new BaseResult(true, APIStatus.Fail, ""));

            }
        }
    }
}
