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

            DateTime startDate = input.CheckinTime;
            DateTime endDate = input.CheckoutTime;
            int dateRange = endDate.Subtract(startDate).Days;
            int roomBasicPrice = (int)room.BasicPrice * dateRange;
            int roomTotalPrice = roomBasicPrice + (int)room.ServiceCharge;

            result.VM = new OrderVM()
            {
                RoomId = input.RoomId,
                Title = room.RoomName,
                RoomInfo = "RoomInfo",
                BedCount = _repo.GetAll<RoomFacility>()
                                .SingleOrDefault(r => r.RoomId == input.RoomId && r.FacilityId == (int)FacilityID.Bed).Quantity,
                BathCount = _repo.GetAll<RoomFacility>()
                                .SingleOrDefault(r => r.RoomId == input.RoomId && r.FacilityId == (int)FacilityID.Bath).Quantity,
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


            result.IsSuccess = true;
            return result;
        }

        
    }
}
