using Front.Models.ViewModels.Rooms;
using MVCModels.Enum;
using System;

namespace Front.Models.DTOModels.Rooms
{
    public class GetRoomsCardOutputDTO : BaseOutputDTO
    {
        public object VM { get; set; }
    }
    public class GetRoomsCardInputDTO
    {
        public City? City { get; set; }
        public DateTime? CheckinTime { get; set; }
        public DateTime? CheckoutTime { get; set; }
        public int? Person { get; set; }

    }
}
