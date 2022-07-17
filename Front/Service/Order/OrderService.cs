using Front.Models.DTOModels.Order;
using Front.Models.DTOModels.RoomDetail;
using Front.Models.ViewModels.Order;
using MVCModels.DataModels;
using MVCModels.MyEnum;
using MVCModels.Repositories;
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
            //this.CreateData();

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
            var order = _repo.GetAll<MVCModels.DataModels.Order>().SingleOrDefault(r => r.RoomId == input.RoomId);

            result.VM = new OrderVM()
            {
                Title = room.RoomName,
                RoomInfo = "RoomInfo",
                BedCount = _repo.GetAll<RoomFacility>()
                                .SingleOrDefault(r => r.RoomId == input.RoomId && r.FacilityId == (int)FacilityID.Bed).Quantity,
                BathCount = _repo.GetAll<RoomFacility>()
                                .SingleOrDefault(r => r.RoomId == input.RoomId && r.FacilityId == (int)FacilityID.Bath).Quantity,
                ImgUrls = _repo.GetAll<ImageFile>()
                                .Where(img => img.RoomId == input.RoomId).Select(img => img.Picture).ToList(),
                RatingScore = CalStar.CalRoomStar(_repo, input.RoomId),
                RentPrice = (int)room.BasicPrice,
                StarDate = order.CheckInDate,
                endDate = order.CheckOutDate,
                DateRange = order.CheckOutDate.Subtract(order.CheckOutDate).Days,
                OrderPrice = (int)room.BasicPrice * (order.CheckOutDate.Subtract(order.CheckOutDate).Days),
                ServiceFee = (int)room.ServiceCharge,
                TotalPrice = (int)room.BasicPrice * (order.CheckOutDate.Subtract(order.CheckOutDate).Days) + (int)room.ServiceCharge,
            };


            result.IsSuccess = true;
            return result;
        }

        
    }
}
