using Front.Models.DTOModels.RoomDetail;
using Front.Service.WishList;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Front.Controllers
{
    [Authorize]

    public class WishListController : Controller
    {
        private readonly IWishListService _service;
        public WishListController(IWishListService service)
        {
            _service = service;
        }
        // GET: WishListController
        //[HttpGet("~/[controller]/[action]/[userId]")]
        public ActionResult WishList()
        {
            var inputDto = new GetWishListInputDTO();
            var userEmail = User.Identity.Name;
            inputDto.UserEmail = userEmail;


            var outputDto = _service.GetWishList(inputDto);

            if (!outputDto.IsSuccess)
            {
                return Redirect("/");
                //return RedirectToAction("Index","Home");
            }
            return View(outputDto.VM);
        }

        
        
    }
}
