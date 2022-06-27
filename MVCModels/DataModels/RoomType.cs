using System;
using System.Collections.Generic;

#nullable disable

namespace MVCModels.DataModels
{
    public partial class RoomType
    {
        public RoomType()
        {
            Rooms = new HashSet<Room>();
        }

        public int RoomTypeId { get; set; }
        public string RoomTypeName { get; set; }
        public int RoomTypeGroupId { get; set; }
        public string RoomTypeGroupName { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }
    }
}
