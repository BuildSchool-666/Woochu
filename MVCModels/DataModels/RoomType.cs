using System;
using System.Collections.Generic;

#nullable disable

namespace MVCModels.DataModels
{
    public partial class RoomType
    {
        public RoomType()
        {
            InverseParent = new HashSet<RoomType>();
            Rooms = new HashSet<Room>();
        }

        public int RoomTypeId { get; set; }
        public string RoomTypeName { get; set; }
        public int? ParentId { get; set; }

        public virtual RoomType Parent { get; set; }
        public virtual ICollection<RoomType> InverseParent { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
    }
}
