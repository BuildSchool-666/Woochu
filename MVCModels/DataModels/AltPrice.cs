using System;
using System.Collections.Generic;

#nullable disable

namespace MVCModels.DataModels
{
    public partial class AltPrice
    {
        public int AltPriceId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int RoomId { get; set; }
        public decimal? Discount { get; set; }
        public decimal BasicPrice { get; set; }
        public decimal? ServiceCharge { get; set; }

        public virtual Room Room { get; set; }
    }
}
