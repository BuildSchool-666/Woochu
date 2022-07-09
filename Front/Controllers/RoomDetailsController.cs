using Microsoft.AspNetCore.Mvc;

namespace Front.Controllers
{
    public class RoomDetailsController : Controller
    {
        public IActionResult RoomDetails()
        {
            return View();
        }
    }
}
