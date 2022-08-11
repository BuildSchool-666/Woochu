using System;
using System.Collections.Generic;

#nullable disable

namespace MVCModels.DataModels
{
    public partial class Order
    {
        public Order()
        {
            Comments = new HashSet<Comment>();
        }

        public string OrderId { get; set; }
        public int CustomerId { get; set; }
        public int HostId { get; set; }
        public DateTime OrderDate { get; set; }
        public int PayedStatus { get; set; }
        public int RoomId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int? AdultCount { get; set; }
        public int? KidCount { get; set; }
        public int? BabyCount { get; set; }
        public decimal TotalPrice { get; set; }

        public virtual User Customer { get; set; }
        public virtual Room Room { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
