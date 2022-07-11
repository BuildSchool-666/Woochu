using System.Collections.Generic;
using MVCModels.MyEnum;
using System;

namespace Front.Models.ViewModels.Rooms
{
    public class RoomFilterForm
    {
        public City City { get; set; }
        public DateTime CheckinTime { get; set; }
        public DateTime CheckoutTime { get; set; }
        public int Person { get; set; }
    }

    public class RoomlistVM
    {
        public string City { get; set; }

        public List<RoomVM> Rooms{ get; set; }
    }


    public class RoomVM
    {
        public string Title { get; set; }
        public string ImgUrl { get; set; }
        public string HouseInfo { get; set; }
        public int BedCount { get; set; }
        public int BathCount { get; set; }
        public int RentPrice { get; set; }
        public double Rating { get; set; }
    }
}
