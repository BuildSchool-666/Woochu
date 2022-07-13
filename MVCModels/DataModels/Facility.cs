using System;
using System.Collections.Generic;

#nullable disable

namespace MVCModels.DataModels
{
    public partial class Facility
    {
        public Facility()
        {
            RoomFacilities = new HashSet<RoomFacility>();
        }

        public int FacilityId { get; set; }
        public string FacilityName { get; set; }
        public bool IsMulti { get; set; }
        public string Icon { get; set; }

        public virtual ICollection<RoomFacility> RoomFacilities { get; set; }
    }
}
