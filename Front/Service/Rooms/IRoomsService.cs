using Front.Models.DTOModels.Rooms;
using Front.Models.ViewModels.Rooms;

namespace Front.Service.Rooms
{
    public interface IRoomsService
    {
        GetRoomsCardOutputDTO GetRoomsCard(GetRoomsCardInputDTO input);
    }
}
