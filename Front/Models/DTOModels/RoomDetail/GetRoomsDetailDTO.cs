using Front.Models.ViewModels.RoomDetails;
using System.Collections.Generic;

namespace Front.Models.DTOModels.RoomDetail
{
    public class GetRoomsDetailOutputDTO : BaseOutputDTO
    {
        public RoomDetailVM VM { get; set; }
    }
    public class GetRoomsDetailInputDTO
    {
        public int RoomId { get; set; }
    }
}
