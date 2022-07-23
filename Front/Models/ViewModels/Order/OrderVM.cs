using System;
using System.Collections.Generic;
using static Front.Models.ViewModels.Order.OrderVM;

namespace Front.Models.ViewModels.Order
{
    public class OrderFilterForm
    {
        public int RoomId { get; set; }

        public DateTime CheckinTime { get; set; }
        public DateTime CheckoutTime { get; set; }
    }

    public class OrderVM
    {
        public int RoomId { get; set; }
        public int CustomerId { get; set; }
        public List<string> ImgUrls { get; set; }
        public string Title { get; set; }
        public string RoomInfo { get; set; }
        public int BedCount { get; set; }
        public int BathCount { get; set; }
        public double RatingStar { get; set; }
        public int RentPrice { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int DateRange { get; set; }
        public int BasicPrice { get; set; }
        public int ServiceFee { get; set; }
        public int TotalPrice { get; set; }

        
    }
}
