using Front.Models.ViewModels.Roomlist;
using Microsoft.AspNetCore.Mvc;

namespace Back.Controllers
{
    public class RoomsController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
        [Route("~/[controller]/[action]/{City?}")]
        public IActionResult roomlist([FromRoute]string City)
        {
            var vm = new RoomlistVM
            {
                city = "Taiwan",
                imgUrl = "https://picsum.photos/300/200/?random=10",
                title = "ooxx",
                HouseInfo = " idiot",
                BedCount = 1,
                BathCount = 1,
                rating = 4.3,
                RentPrice = 200,
            };
            return View(vm);
        }
        public IActionResult roomlistPage2()
        {
            return View();
        }
        public IActionResult roomlistPage3()
        {
            return View();
        }
        public IActionResult roomtype()
        {
            return View();
        }

    }
}
