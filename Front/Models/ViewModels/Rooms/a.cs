using MVCModels.Enum;
using System;

namespace Front.Models.ViewModels.Rooms
{
    public class RoomFilterForm
    {
        public City City { get; set; }
        public DateTime CheckinTime { get; set; }
        public DateTime CheckoutTime { get; set; }
        public int Person { get; set; }
    }


}
