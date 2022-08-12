using System.Collections.Generic;

namespace Front.Models.ViewModels.PublishRoom
{
    public class PublishRoomVM
    {
        public int RoomTypeId { get; set; }
        public string RoomTypeName { get; set; }

        public string UserEmail { get; set; }
        //public int RoomPrivacyId { get; set; }
        //public string RoomPrivacyName { get; set; }
        //public List<RoomTypeVM> RoomTypeItem { get; set; }
        //public List<RoomPrivacyVM> RoomPrivacyItem { get; set; }
    }
    public class RoomTypeVM
    {
        public int RoomTypeId { get; set; }
        public string RoomTypeName { get; set; }
    }
    public class RoomPrivacyVM
    {
        public int RoomPrivacyId { get; set; }
        public string RoomPrivacyName { get; set; }
    }

}
