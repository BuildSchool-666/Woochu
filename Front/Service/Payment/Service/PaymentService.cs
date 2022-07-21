using System;
using Front.Models.DTOModels.Payment;
using Front.Models.ViewModels.Payment;
using MVCModels.Repositories;
using MVCModels.DataModels;
using System.Linq;
using Front.Models.DTOModels.RoomDetail;
using Front.Models.ViewModels.RoomDetails;
using Front.Models.DTOModels;

namespace Front.Service.Payment.Service
{
    public class PaymentService : IPaymentService
    {
        private readonly WoochuRepository _repo;

        public PaymentService(WoochuRepository repo)
        {
            _repo = repo;
        }
        public GetRoomsDetailOutputDTO GetRoom(int id)
        {
            var result = new GetRoomsDetailOutputDTO
            {
                IsSuccess = false,
            };
            var room = _repo.GetAll<Room>().SingleOrDefault(r => r.RoomId == id);

            result.VM = new RoomDetailVM
            {
                RoomId = id,
                Title = room.RoomName,
                RentPrice = (int)room.BasicPrice,
                PersonCount = (int)room.GuestCount,
            };
            result.IsSuccess = true;

            return result;
        }

        public CreateOrderOutputDTO CreateOrder(CreateOrderInputDTO input)
        {
            var result = new CreateOrderOutputDTO()
            {
                IsSuccess = false,
            };
            var entity = new MVCModels.DataModels.Order()
            {
                OrderId = int.Parse(input.OrderId),
                CustomerId = input.CustomerId,
                HostId = _repo.GetAll<Room>().SingleOrDefault(r => r.RoomId == input.RoomId).UserId,
                OrderDate = input.OrderDate.DateTime,
                CheckInDate = input.CheckinTime,
                CheckOutDate = input.CheckoutTime,
                PayedStatus = 1,
                RoomId = input.RoomId,
                AdultCount = input.Quantity,
                TotalPrice = input.TotalPrice,
            };
            try
            {
                _repo.Create<MVCModels.DataModels.Order>(entity);
                _repo.SaveChanges();
                result.IsSuccess = true;
            }
            catch(Exception ex)
            {
                result.Message = ex.Message;
            }

            return result;
        }
        public BaseOutputDTO UpdatePayedStatus(string id)
        {
            var result = new BaseOutputDTO
            {
                IsSuccess = false,
            };
            var order = _repo.GetAll<MVCModels.DataModels.Order>().SingleOrDefault(o => o.OrderId == int.Parse(id));
            try
            {
                order.PayedStatus = 2;
                _repo.SaveChanges();
                result.IsSuccess = true;
            }
            catch(Exception ex)
            {
                result.Message = ex.Message;
            }
            
            return result;
        }
    }
}

