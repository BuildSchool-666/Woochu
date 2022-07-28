using Front.Models.DTOModels.Photo;
using Front.Service.Account_setting;
using Front.Service.Photo;
using Microsoft.AspNetCore.Mvc;

namespace Front.Controllers
{
    [Route("api/[controller")]
    [ApiController]
    public class PhotoController : Controller
    {
        private readonly IPhotoService _photoService;
        private IImageService _imageService;

        public PhotoController(IPhotoService photoService, IImageService imageService)
        {
            _photoService = photoService;
            _imageService = imageService;
        }
        //[HttpPost("add")]
        //public IActionResult AddImage(int userId,[FromForm] PhotoForCreation photoForCreation)
        //{
        //    var profilePhoto = _photoService.AddPhotoForUser(userId,photoForCreation);
        //    var result = _imageService.AddImage(profilePhoto);
        //    if(result.Succeeded)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest();
        //}
    }
}
