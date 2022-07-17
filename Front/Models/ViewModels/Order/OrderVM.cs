using System;
using System.Collections.Generic;
using static Front.Models.ViewModels.Order.OrderVM;

namespace Front.Models.ViewModels.Order
{
    public class OrderFilterForm
    {
        public DateTime CheckinTime { get; set; }
        public DateTime CheckoutTime { get; set; }
    }

    public class OrderVM
    {
        public List<string> ImgUrls { get; set; }
        public string Title { get; set; }
        public string RoomInfo { get; set; }
        public int BedCount { get; set; }
        public int BathCount { get; set; }
        public double RatingScore { get; set; }
        public int RentPrice { get; set; }

        public DateTime StarDate { get; set; }
        public DateTime endDate { get; set; }
        public int DateRange { get; set; }
        public int OrderPrice { get; set; }
        public int TotalPrice { get; set; }
        public int ServiceFee { get; set; }

        
    }
}
