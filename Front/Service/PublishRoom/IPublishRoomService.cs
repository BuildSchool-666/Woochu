
using Front.Models.DTOModels.PublishRoom;
using Front.Models.ViewModels.PublishRoom;
using System.Collections.Generic;

namespace Front.Service.PublishRoom
{
    public interface IPublishRoomService
    {
        int CreateRoom(PublishRoomApiInputDTO input);
        void CreateImage(PublishRoomApiInputDTO input, int roomId);
        void CreateFacility(PublishRoomApiInputDTO input, int roomId);

        IEnumerable<PublishRoomVM> GetRoomTypeParent();
        IEnumerable<PublishRoomVM> GetRoomType(int ParentId);
        IEnumerable<PublishRoomVM> GetFacility();


    }
}
