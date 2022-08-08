using Front.Models.DTOModels;
using Front.Models.ViewModels.Comment;
using Front.Models.ViewModels.Rooms;
using Front.Service.Comment;
using Microsoft.AspNetCore.Mvc;

namespace Front.Controllers
{

    public class CommentController : Controller
    {
        private readonly ICommentService _service;

        public CommentController(ICommentService service)
        {
            _service = service;
        }


        public IActionResult Comment()
        {
            var inputDTO = new GetCommentInputDTO();
            
            var userEmail = User.Identity.Name;

            inputDTO.Email = userEmail;

            var outputDTO = _service.GetComment(inputDTO);
            if (!outputDTO.IsSuccess)
            {
                return Redirect("/");
                //return RedirectToAction("Index","Home");
            }



            return View(outputDTO.vm);
        }

        //public IActionResult Comment()
        //{
        //    var inputDTO = new GetCommentInputDTO()
        //    {
        //        Email = User.Identity.Name,
        //    };

        //    var outputDTO = _service.GetComment(inputDTO);



        //    return View(outputDTO);
        //}
    }
}
