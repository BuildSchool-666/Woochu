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
        public int CommentId { get; set; }
        public int star { get; set; }
        public string comment { get; set; }
        public DateTime Created { get; set; }
        public string Email { get; set; }
        public int RoomId { get; set; }
        public int Cleanliness { get; set; }
        public int Accuracy { get; set; }
        public int Communication { get; set; }
        public int CheckIn { get; set; }
        public int Cp { get; set; }
        public int Location { get; set; }
    }
    public class CommentApiOutputDTO : BaseOutputDTO
    {

    }
}
