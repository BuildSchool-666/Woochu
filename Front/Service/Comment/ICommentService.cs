using Front.Models.DTOModels;

namespace Front.Service.Comment
{
    public interface ICommentService
    {
        GetCommentOutputDTO GetComment(GetCommentInputDTO input);
        CommentApiOutputDTO CreateComment(CommentApiInputDTO input);
        CommentApiOutputDTO DeleteComment(CommentApiInputDTO input);

    }
}
