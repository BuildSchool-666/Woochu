using System;
//using Front.Models.ViewModels.Payment;

namespace Front.Models.DTOModels.Payment
{
    public class CreateOrderInputDTO
    {
        public string OrderId { get; set; }
        public int RoomId { get; set; }
        public int CustomerId { get; set; }
        //public int HostId { get; set; }
        public DateTimeOffset OrderDate { get; set; }
        public DateTime CheckinTime { get; set; }
        public DateTime CheckoutTime { get; set; }
        public int BasicPrice { get; set; }
        public int Quantity { get; set; }
        public int ServiceFee { get; set; }
        public int TotalPrice { get; set; }

    }
    public class CreateOrderOutputDTO : BaseOutputDTO
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int HostId { get; set; }
        public DateTime OrderDate { get; set; }
        public int PayedStatus { get; set; }
        public int RoomId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public decimal BasicPrice { get; set; }
        public int Quantity { get; set; }
        public decimal ServiceFee { get; set; }
        public decimal TotalPrice { get; set; }
    }
}

