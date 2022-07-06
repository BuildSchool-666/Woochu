using System;
using System.Collections.Generic;

#nullable disable

namespace MVCModels.DataModels
{
    public partial class HostApplication
    {
        public int HostId { get; set; }
        public int UserId { get; set; }
        public string BankAccount { get; set; }
        public DateTime ApplyTime { get; set; }
        public int VerifyState { get; set; }
        public string VerifyData { get; set; }
        public int? AuditRejectReason { get; set; }
        public DateTime? AuditTime { get; set; }

        public virtual User User { get; set; }
    }
}
