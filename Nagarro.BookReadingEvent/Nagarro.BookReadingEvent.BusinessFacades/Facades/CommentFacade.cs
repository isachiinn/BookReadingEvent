using Nagarro.BookReadingEvent.Shared;
using System.Collections.Generic;

namespace Nagarro.BookReadingEvent.BusinessFacades
{
    public class CommentFacade : FacadeBase, ICommentFacade
    {
        public CommentFacade()
           : base(FacadeType.CommentFacade)
        {

        }

        public OperationResult<CommentDTO> AddNewComment(CommentDTO commentDTO)
        {
            ICommentBDC commentBDC = (ICommentBDC)BDCFactory.Instance.Create(BDCType.CommentBDC);
            return commentBDC.AddNewComment(commentDTO);
        }

        public List<CommentDTO> GetAllCommentsOfAnEvent(int EventId)
        {
            ICommentBDC commentBDC = (ICommentBDC)BDCFactory.Instance.Create(BDCType.CommentBDC);
            return commentBDC.GetAllCommentsOfAnEvent(EventId);
        }

        public List<CommentDTO> GetAllCommentsOfAUser(string Username)
        {
            ICommentBDC commentBDC = (ICommentBDC)BDCFactory.Instance.Create(BDCType.CommentBDC);
            return commentBDC.GetAllCommentsOfAUser(Username);
        }
    }
}
