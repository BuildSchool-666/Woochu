using System;
using System.Collections.Generic;

namespace Front.Models.ViewModels.Comment
{
    public class PostCommentViewModel
    {
        public DateTime Created { get; set; }
        public string Comment { get; set; }
        public int star { get; set; }
        public string Email { get; set; }

    }

    public class CommentlistVM
    {

        public List<CommentVM> Comment { get; set; }



    }

    public class CommentVM
    {
        public int UserId { get; set; }
        public int? commentId { get; set; }
        public int RoomId { get; set; }
        public string RoomTitle { get; set; }
        public string HostName { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public decimal TotalPrice { get; set; }
        public string Email { get; set; }
        public string? content { get; set; }


    }
    //public class CommentId
    //{
    //    public int commentId { get; set; }
    //}


    public class OrderList
    {
        public DateTime OrderDate { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }

    }

    public class CommentStar
    {
        public double Cleanlines { get; set; }
        public double Accuracy { get; set; }
        public double Communication { get; set; }
        public double Location { get; set; }
        public double CheckIn { get; set; }
        public double CP { get; set; }
    }

}
