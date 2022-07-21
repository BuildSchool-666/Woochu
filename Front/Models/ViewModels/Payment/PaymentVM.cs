using System;
namespace Front.Models.ViewModels.Payment
{
    public class PaymentVM
    {
        public int RoomId { get; set; }
        public DateTime CheckinTime { get; set; }
        public DateTime CheckoutTime { get; set; }
        public int BasicPrice { get; set; }
        public int Quantity { get; set; }
        public int ServiceFee { get; set; }
        public int TotalPrice { get; set; }
    }
}

