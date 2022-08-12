
using Front.Models.DTOModels.PublishRoom;
using Front.Models.ViewModels.PublishRoom;
using System.Collections.Generic;

namespace Front.Service.PublishRoom
{
    public interface IPublishRoomService
    {
        PublishRoomApiOutputDTO CreateRoom(int roomTypeId, string userEmail);
        PublishRoomApiOutputDTO UpdateRoom(PublishRoomApiInputDTO input);
        IEnumerable<PublishRoomVM> GetRoomTypeParent();
        IEnumerable<PublishRoomVM> GetRoomType(int ParentId);

    }
}
