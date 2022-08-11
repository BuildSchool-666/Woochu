using Front.Models.ViewModels.Comment;
using System;
using System.Collections.Generic;

namespace Front.Models.DTOModels
{
    public class GetCommentOutputDTO : BaseOutputDTO
    {
        public CommentlistVM vm { get; set; }
    }
    public class GetCommentInputDTO
    {
        public string Email { get; set; }
    }



    public class CommentApiInputDTO
    {
        public double Cleanliness { get; set; }
        public double Accuracy { get; set; }
        public double Communication { get; set; }
        public double Location { get; set; }
        public double CheckIn { get; set; }
        public double CP { get; set; }
        public int CommentId { get; set; }
        public string comment { get; set; }
        public DateTime Created { get; set; }
        public string Email { get; set; }
        public int RoomId { get; set; }
        public string OrderId { get; set; }
    }
    

        public class CommentApiOutputDTO : BaseOutputDTO
    {

    }
}
