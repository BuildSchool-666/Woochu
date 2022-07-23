using Front.Models.ViewModels.Order;
using MVCModels.MyEnum;
using System;

namespace Front.Models.DTOModels.Order
{
    public class GetOrderOutputDTO : BaseOutputDTO
    {
        public OrderVM VM { get; set; }
    }
    public class GetorderDetailInputDTO
    {
        public int RoomId { get; set; }
        public string CustomerMail { get; set; }
        public DateTime CheckinTime { get; set; }
        public DateTime CheckoutTime { get; set; }

    }
    

}
