using System;
using System.Collections.Generic;

#nullable disable

namespace MVCModels.DataModels
{
    public partial class WishList
    {
        public int WishListId { get; set; }
        public int UserId { get; set; }
        public int RoomId { get; set; }
        public DateTime InsertTime { get; set; }

        public virtual Room Room { get; set; }
        public virtual User User { get; set; }
    }
}
