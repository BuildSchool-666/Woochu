using Front.Models.DTOModels.Order;
using Front.Models.DTOModels.RoomDetail;
using Front.Models.ViewModels.Order;
using MVCModels.DataModels;
using MVCModels.MyEnum;
using MVCModels.Repositories;
using System;
using System.Linq;

namespace Front.Service.Order
{
    public class OrderService : IOrderService
    {
        private readonly WoochuRepository _repo;

        public OrderService(WoochuRepository repo)
        {
            _repo = repo;
        }

        public GetOrderOutputDTO GetOrderData(GetorderDetailInputDTO input)
        {

            var result = new GetOrderOutputDTO
            {
                IsSuccess = false,
                VM = new OrderVM(),
            };

            if (false)
            {
                result.Message = "some failure msg";

            }
            var room = _repo.GetAll<Room>().SingleOrDefault(r => r.RoomId == input.RoomId);
            var customer = _repo.GetAll<User>().SingleOrDefault(c => c.Email == input.CustomerMail);

            DateTime startDate = input.CheckinTime;
            DateTime endDate = input.CheckoutTime;
            int dateRange = endDate.Subtract(startDate).Days;
            int roomBasicPrice = (int)room.BasicPrice * dateRange;
            int roomTotalPrice = roomBasicPrice + (int)room.ServiceCharge;

            result.VM = new OrderVM()
            {
                RoomId = input.RoomId,
                CustomerId = customer.UserId,
                Title = room.RoomName,
                RoomInfo = "RoomInfo",
                ImgUrls = _repo.GetAll<ImageFile>()
                                .Where(img => img.RoomId == input.RoomId).Select(img => img.Picture).ToList(),
                RatingStar = CalStar.CalRoomStar(_repo, input.RoomId),
                BasicPrice = (int)room.BasicPrice,
                StartDate = startDate,
                EndDate = endDate,
                DateRange = dateRange,
                RentPrice= roomBasicPrice,
                ServiceFee = (int)room.ServiceCharge,
                TotalPrice = roomTotalPrice,
            };
            try
            {
                result.VM.BedCount = _repo.GetAll<RoomFacility>()
                                .SingleOrDefault(r => r.RoomId == input.RoomId && r.FacilityId == (int)FacilityID.Bed).Quantity;
                result.VM.BathCount = _repo.GetAll<RoomFacility>()
                                .SingleOrDefault(r => r.RoomId == input.RoomId && r.FacilityId == (int)FacilityID.Bath).Quantity;
            }
            catch
            {
                result.VM.BedCount = 0;
                result.VM.BathCount = 0;
            }

            result.IsSuccess = true;
            return result;
        }

        
    }
}
