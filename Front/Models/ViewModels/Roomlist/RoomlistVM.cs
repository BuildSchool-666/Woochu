using System.Collections.Generic;

namespace Front.Models.ViewModels.Roomlist
{
    public class RoomlistVM
    {
        public string city { get; set; }
        public string imgUrl { get; set; }
        public string title { get; set; }
        public string HouseInfo { get; set; }
        public int BedCount { get; set; }
        public int BathCount { get; set; }
        public double rating { get; set; }
        public int RentPrice { get; set; }
    }
}
