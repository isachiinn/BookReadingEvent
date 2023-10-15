using System.Collections.Generic;

namespace Nagarro.BookReadingEvent.Shared
{
    public interface ICommentDAC : IDataAccessComponent
    {
        CommentDTO AddNewComment(CommentDTO commentDTO);
        List<CommentDTO> GetAllCommentsOfAUser(string Username);
        List<CommentDTO> GetAllCommentsOfAnEvent(int EventId);
    }
}
