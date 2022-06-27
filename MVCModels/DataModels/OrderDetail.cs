using System;
using System.Collections.Generic;

#nullable disable

namespace MVCModels.DataModels
{
    public partial class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int RoomId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int? AdultCount { get; set; }
        public int? KidCount { get; set; }
        public int? BabyCount { get; set; }
        public decimal TotalPrice { get; set; }

        public virtual Order Order { get; set; }
        public virtual Room Room { get; set; }
    }
}
