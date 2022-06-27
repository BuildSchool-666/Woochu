using System;
using System.Collections.Generic;

#nullable disable

namespace MVCModels.DataModels
{
    public partial class Message
    {
        public int UserId { get; set; }
        public int HostId { get; set; }
        public string Message1 { get; set; }
        public DateTime CreateTime { get; set; }

        public virtual User User { get; set; }
    }
}
