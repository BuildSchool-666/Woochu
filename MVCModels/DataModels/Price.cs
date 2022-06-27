using System;
using System.Collections.Generic;

#nullable disable

namespace MVCModels.DataModels
{
    public partial class Price
    {
        public int PriceId { get; set; }
        public int? RoomId { get; set; }
        public decimal BasicPrice { get; set; }
        public decimal? ServiceCharge { get; set; }
        public decimal? Discount { get; set; }

        public virtual Room Room { get; set; }
    }
}
