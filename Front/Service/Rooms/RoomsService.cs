using Front.Models.DTOModels.Rooms;
using Front.Models.ViewModels.Rooms;
using MVCModels.DataModels;
using MVCModels.Repositories;
using System.Linq;

namespace Front.Service.Rooms
{
    public class RoomsService : IRoomsService
    {
        private readonly WoochuRepository _repo;

        public RoomsService(WoochuRepository repo)
        {
            _repo = repo;
        }
        public GetRoomsCardOutputDTO GetRoomsCard(GetRoomsCardInputDTO input)
        {
            var result = new GetRoomsCardOutputDTO
            {
                IsSuccess = false,
                VM = new object(),
            };

            if (false)
            {
                result.Message = "some failure msg";
            }

            var tmp = _repo.GetAll<Room>();

            if (input.City != 0)
            {
                tmp = tmp.Where(r => r.City == input.City.ToString());
            }

            if (input.CheckinTime != null && input.CheckoutTime != null)
            {
                //tmp = tmp.Where(r => r.City == input.City.ToString());

                //選取日期不能跟RoomEvent日期有交集
            }

            if (input.Person != 0)
            {
                tmp = tmp.Where(r => r.GuestCount >= input.Person);
            }

            result.VM = tmp.Select(r => new
            {

            });

            result.IsSuccess = true;

            return result;
        }
    }
}
