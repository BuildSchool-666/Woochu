using Front.Models.ViewModels.Rooms;
using MVCModels.MyEnum;
using System;

namespace Front.Models.DTOModels.Rooms
{
    public class GetRoomsCardOutputDTO : BaseOutputDTO
    {
        public RoomlistVM VM { get; set; }
    }
    public class GetRoomsCardInputDTO
    {
        public string Email { get; set; }
        public City City { get; set; }
        public DateTime? CheckinTime { get; set; }
        public DateTime? CheckoutTime { get; set; }
        public int Person { get; set; }

    }
}
