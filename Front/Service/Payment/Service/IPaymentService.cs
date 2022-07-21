using System;
using Front.Models.DTOModels;
using Front.Models.DTOModels.Payment;
using Front.Models.DTOModels.RoomDetail;

namespace Front.Service.Payment.Service
{
    public interface IPaymentService
    {
        public CreateOrderOutputDTO CreateOrder(CreateOrderInputDTO input);
        public GetRoomsDetailOutputDTO GetRoom(int id);
        public BaseOutputDTO UpdatePayedStatus(string id);
    }
}

