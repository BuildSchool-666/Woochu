using System;
using System.Collections.Generic;

#nullable disable

namespace MVCModels.DataModels
{
    public partial class User
    {
        public User()
        {
            Comments = new HashSet<Comment>();
            HostApplications = new HashSet<HostApplication>();
            Orders = new HashSet<Order>();
            Rooms = new HashSet<Room>();
            WishLists = new HashSet<WishList>();
        }

        public int UserId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public bool IsHost { get; set; }
        public int? Gender { get; set; }
        public DateTime? Dob { get; set; }
        public string Email { get; set; }
        public bool? EmailVerify { get; set; }
        public string Phone { get; set; }
        public bool? PhoneConfirmed { get; set; }
        public string Password { get; set; }
        public string Ic { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string EmergencyContactName { get; set; }
        public string EmergencyContactRelation { get; set; }
        public string EmergencyContactEmail { get; set; }
        public string EmergencyContactNumber { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? LastOnlineTime { get; set; }
        public string PersonalPhoto { get; set; }
        public string About { get; set; }
        public int? AverageReplyTime { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<HostApplication> HostApplications { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
        public virtual ICollection<WishList> WishLists { get; set; }
    }
}
