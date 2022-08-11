using System;

namespace Front.Models.DTOModels.PublishRoom
{
    public class PublishRoomApiInputDTO
    {
        public int RoomId { get; set; }
        public string RoomName { get; set; }
        public int UserId { get; set; }
        public int RoomTypeId { get; set; }
        public int? PrivacyTypeId { get; set; }
        public int? GuestCount { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public decimal? Longitude { get; set; }
        public decimal? Latitude { get; set; }
        public DateTime UpdateTime { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? PublishTime { get; set; }
        public int? RoomStatus { get; set; }
        public string Description { get; set; }
        public int? BrowseCount { get; set; }
        public decimal? Discount { get; set; }
        public decimal? BasicPrice { get; set; }
        public decimal? ServiceCharge { get; set; }
        public string UserEmail { get; set; }
    }
    public class PublishRoomApiOutputDTO : BaseOutputDTO
    {
    }

}
