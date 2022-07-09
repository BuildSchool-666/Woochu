using System.Collections.Generic;

namespace Front.Models.ViewModels.RoomDetails
{

    public class RoomDetailsVM
    {
        public string Title { get; set; }

        public string Address { get; set; }
        public string RoomInfo { get; set; }
        public int BedCount { get; set; }
        public int BathCount { get; set; }
        public int RentPrice { get; set; }
        public double Rating { get; set; }

        public List <string> ImgUrls { get; set; }

        public string Discribtion { get; set; }

        public string HostName { get; set; }
        public int JoinTime { get; set; }
        public int ReplyTime { get; set; }
        public int LastOnlineTime { get; set; }


    }
}
