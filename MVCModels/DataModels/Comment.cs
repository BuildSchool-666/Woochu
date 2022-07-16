using System;
using System.Collections.Generic;

#nullable disable

namespace MVCModels.DataModels
{
    public partial class Comment
    {
        public int CommentId { get; set; }
        public int RoomId { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; }
        public DateTime CreateTime { get; set; }
        public bool IsDelete { get; set; }
        public double Cleanliness { get; set; }
        public double Accuracy { get; set; }
        public double Communication { get; set; }
        public double Location { get; set; }
        public double CheckIn { get; set; }
        public double Cp { get; set; }
        public DateTime? AuditTime { get; set; }
        public int? AuditRejectReason { get; set; }

        public virtual Room Room { get; set; }
        public virtual User User { get; set; }
    }
}
