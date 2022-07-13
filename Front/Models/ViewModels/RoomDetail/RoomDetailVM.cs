using System;
using System.Collections.Generic;

namespace Front.Models.ViewModels.RoomDetails
{

    public class RoomDetailVM
    {
        public string Title { get; set; }
        public string Address { get; set; }
        public string RoomInfo { get; set; }
        public int BrowseCount { get; set; }
        public int BedCount { get; set; }
        public int PersonCount { get; set; }
        public int BathCount { get; set; }
        public List <string> ImgUrls { get; set; }
        public List<FacilityIcon>? FacilityItem { get; set; }
        public int RentPrice { get; set; }
        public string Description { get; set; }
        public double CleanlinessStar { get; set; }
        public double AccuracyStar { get; set; }
        public double CommunicationStar { get; set; }
        public double LocationStar { get; set; }
        public double CheckInStar { get; set; }
        public double ValueStar { get; set; }
        public double RatingStar { get; set; }
        public int CommentCount { get; set; }
        public List<CommentInformation>? CommentItem { get; set; }
        public int HostId { get; set; }
        public string HostName { get; set; }
        public DateTime JoinTime { get; set; }
        public int LastOnlineTime { get; set; }
    }
    public class FacilityIcon
    {
        public string FacilityName { get; set; }
        public string FacilityDisplay { get; set; }
    }
    public class CommentInformation
    {
        public string CommentName { get; set; }
        public string CommentContent { get; set; }
        public DateTime CommentDate { get; set; }
        public double PersonRatingStar { get; set; }
    }
    public class CommentStar
    {
        public double CleanlinessStar { get; set; }
        public double AccuracyStar { get; set; }
        public double CommunicationSt { get; set; }
        public double LocationStar { get; set; }
        public double CheckInStar { get; set; }
        public double ValueStar { get; set; }
    }
}
