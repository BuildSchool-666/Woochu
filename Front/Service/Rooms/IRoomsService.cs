using Front.Models.DTOModels.Rooms;
using Front.Models.ViewModels.Rooms;
using System.Collections.Generic;

namespace Front.Service.Rooms
{
    public interface IRoomsService
    {
        GetRoomsCardOutputDTO GetRoomsCard(GetRoomsCardInputDTO input);
        List<GetRoomTypeOutputDTO> GetRoomType();
        List<GetFacilityOutputDTO> GetFacility();
    }
}
