using System;
using System.Collections.Generic;

#nullable disable

namespace MVCModels.DataModels
{
    public partial class Room
    {
        public Room()
        {
            AltPrices = new HashSet<AltPrice>();
            Comments = new HashSet<Comment>();
            ImageFiles = new HashSet<ImageFile>();
            Orders = new HashSet<Order>();
            RoomEvents = new HashSet<RoomEvent>();
            RoomFacilities = new HashSet<RoomFacility>();
            WishLists = new HashSet<WishList>();
        }

        public int RoomId { get; set; }
        public string RoomName { get; set; }
        public int UserId { get; set; }
        public int RoomTypeId { get; set; }
        public int PrivacyTypeId { get; set; }
        public int GuestCount { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
        public DateTime UpdateTime { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime PublishTime { get; set; }
        public int RoomStatus { get; set; }
        public string Description { get; set; }
        public int BrowseCount { get; set; }
        public decimal? Discount { get; set; }
        public decimal BasicPrice { get; set; }
        public decimal? ServiceCharge { get; set; }

        public virtual RoomType RoomType { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<AltPrice> AltPrices { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<ImageFile> ImageFiles { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<RoomEvent> RoomEvents { get; set; }
        public virtual ICollection<RoomFacility> RoomFacilities { get; set; }
        public virtual ICollection<WishList> WishLists { get; set; }
    }
}
