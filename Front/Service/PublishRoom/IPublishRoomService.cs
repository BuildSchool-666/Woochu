
using Front.Models.DTOModels.PublishRoom;
using Front.Models.ViewModels.PublishRoom;
using System.Collections.Generic;

namespace Front.Service.PublishRoom
{
    public interface IPublishRoomService
    {
        PublishRoomApiOutputDTO CreateRoom(PublishRoomApiInputDTO input);
        PublishRoomApiOutputDTO UpdateRoom(PublishRoomApiInputDTO input);
        IEnumerable<RoomTypeVM> GetRoomTypeParent();
        IEnumerable<RoomTypeVM> GetRoomType();

    }
}
