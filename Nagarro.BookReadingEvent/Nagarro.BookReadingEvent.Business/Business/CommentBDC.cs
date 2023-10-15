using Nagarro.BookReadingEvent.Shared;
using System;
using System.Collections.Generic;

namespace Nagarro.BookReadingEvent.Business
{
    public class CommentBDC : BDCBase, ICommentBDC
    {
        private readonly IDACFactory dacFactory;

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        public CommentBDC()
            : base(BDCType.EventBDC)
        {
            dacFactory = DACFactory.Instance;
        }

        public CommentBDC(IDACFactory dacFactory)
            : base(BDCType.EventBDC)
        {
            this.dacFactory = dacFactory;
        }

        public OperationResult<CommentDTO> AddNewComment(CommentDTO commentDTO)
        {
            OperationResult<CommentDTO> retVal = null;
            try
            {
                NagarroSampleValidationResult validationResult = Validator<CommentValidator, CommentDTO>.Validate(commentDTO);
                if (validationResult.IsValid)
                {
                    ICommentDAC commentDAC = (ICommentDAC)dacFactory.Create(DACType.CommentDAC);
                    CommentDTO resultDTO = commentDAC.AddNewComment(commentDTO);
                    if (resultDTO != null)
                    {
                        retVal = OperationResult<CommentDTO>.CreateSuccessResult(resultDTO);
                    }
                    else
                    {
                        retVal = OperationResult<CommentDTO>.CreateFailureResult("Failed!");
                    }
                }
                else
                {
                    retVal = OperationResult<CommentDTO>.CreateFailureResult(validationResult);
                }
            }
            catch (DACException dacEx)
            {
                retVal = OperationResult<CommentDTO>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                retVal = OperationResult<CommentDTO>.CreateErrorResult(ex.Message, ex.StackTrace);
            }

            return retVal;
        }

        public List<CommentDTO> GetAllCommentsOfAnEvent(int EventId)
        {
            ICommentDAC commentDAC = (ICommentDAC)dacFactory.Create(DACType.CommentDAC);
            return commentDAC.GetAllCommentsOfAnEvent(EventId);
        }

        public List<CommentDTO> GetAllCommentsOfAUser(string Username)
        {
            ICommentDAC commentDAC = (ICommentDAC)dacFactory.Create(DACType.CommentDAC);
            return commentDAC.GetAllCommentsOfAUser(Username);
        }
        #endregion
    }
}
