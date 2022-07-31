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
        //public int Person { get; set; }
    }

    public class RoomlistVM
    {
        public string City { get; set; }

        public List<RoomVM> Rooms{ get; set; }
    }


    public class RoomVM
    {
        public int RoomId { get; set; }
        public string Title { get; set; }
        public string ImgUrl { get; set; }
        public string HouseInfo { get; set; }
        public int BedCount { get; set; }
        public int BathCount { get; set; }
        public int RentPrice { get; set; }
        public double Rating { get; set; }
        public int RoomTypeId { get; set; }
        public List<FacilityIcon>? FacilityItem { get; set; }
    }

    public class FacilityIcon
    {
        public int FacilityId { get; set; }
        public string FacilityName { get; set; }
        //public string FacilityDisplay { get; set; }
    }
}
