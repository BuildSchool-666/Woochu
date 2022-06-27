using System;
using System.Collections.Generic;

#nullable disable

namespace MVCModels.DataModels
{
    public partial class RoomEvent
    {
        public int EventId { get; set; }
        public int EventName { get; set; }
        public DateTime EventStartDate { get; set; }
        public DateTime EventEndDate { get; set; }
        public int RoomId { get; set; }

        public virtual Room Room { get; set; }
    }
}
