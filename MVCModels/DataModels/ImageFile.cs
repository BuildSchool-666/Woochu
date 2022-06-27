using System;
using System.Collections.Generic;

#nullable disable

namespace MVCModels.DataModels
{
    public partial class ImageFile
    {
        public int ImageId { get; set; }
        public int RoomId { get; set; }
        public string Picture { get; set; }
        public int ImageSort { get; set; }

        public virtual Room Room { get; set; }
    }
}
