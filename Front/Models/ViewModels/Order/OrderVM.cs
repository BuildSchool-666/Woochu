using System;

namespace Front.Models.ViewModels.Order
{
    public class OrderVM
    {
        public string ImgUrll { get; set; }
        public string ImgUrl2 { get; set; }
        public string ImgUrl3 { get; set; }
        public string ImgUrl4 { get; set; }
        public string ImgUrl5 { get; set; }

        public string Title { get; set; }
        public string RoomInfo { get; set; }
        public int BedCount { get; set; }
        public int BathCount { get; set; }
        public double RatingScore { get; set; }
        public int RentPrice { get; set; }

        public string StarDate { get; set; }
        public string endDate { get; set; }
        public int DateRange { get; set; }
        public int OrderPrice { get; set; }
        public int TotalPrice { get; set; }
        public int ServiceFee { get; set; }

       
    }
}
