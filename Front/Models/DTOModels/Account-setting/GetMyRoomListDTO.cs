using Front.Models.ViewModels.Rooms;
using System.Collections.Generic;

namespace Front.Models.DTOModels.Account_setting
{
        public class GetMyRoomListOutputDTO : BaseOutputDTO
        {
            public List<RoomVM> VM { get; set; }

        }
        public class GetMyRoomInputDTO
        {
            public string Email { get; set; }
        }

}
