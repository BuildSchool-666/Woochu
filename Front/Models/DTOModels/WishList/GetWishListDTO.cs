using Front.Models.ViewModels.RoomDetails;
using Front.Models.ViewModels.Rooms;
using Front.Models.ViewModels.WishListVM;
using System.Collections.Generic;

namespace Front.Models.DTOModels.RoomDetail
{
    public class GetWishListOutputDTO : BaseOutputDTO
    {
        public RoomlistVM VM { get; set; }
    }
    public class GetWishListInputDTO
    {
        public string UserEmail { get; set; }
        //public string Email { get; set; }
    }
}
