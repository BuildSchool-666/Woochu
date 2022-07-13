using Front.Models.DTOModels.RoomDetail;

namespace Front.Service.RoomDetail
{
    public interface IRoomDetailService
    {
        GetRoomsDetailOutputDTO GetRoomsDetail(GetRoomsDetailInputDTO input);
    }
}
