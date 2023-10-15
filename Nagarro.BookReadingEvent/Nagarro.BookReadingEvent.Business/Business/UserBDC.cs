using Nagarro.BookReadingEvent.Shared;
using System;
using System.Collections.Generic;

namespace Nagarro.BookReadingEvent.Business
{
    public class UserBDC : BDCBase, IUserBDC
    {
        private readonly IDACFactory dacFactory;

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        public UserBDC()
            : base(BDCType.UserBDC)
        {
            dacFactory = DACFactory.Instance;
        }

        public UserBDC(IDACFactory dacFactory)
            : base(BDCType.UserBDC)
        {
            this.dacFactory = dacFactory;
        }
        #endregion

        public UserDTO GetUserById(int UserId)
        {
            IUserDAC userDAC = (IUserDAC)dacFactory.Create(DACType.UserDAC);
            return userDAC.GetUserById(UserId);
        }


        public List<UserDTO> GetAllUsers()
        {
            IUserDAC userDAC = (IUserDAC)dacFactory.Create(DACType.UserDAC);
            List<UserDTO> result = userDAC.GetAllUsers();
            return result;
        }

        public OperationResult<UserDTO> RegisterUser(UserDTO userDTO)
        {
            OperationResult<UserDTO> retVal = null;
            try
            {
                NagarroSampleValidationResult validationResult = Validator<UserValidator, UserDTO>.Validate(userDTO);
                if (validationResult.IsValid)
                {
                    IUserDAC userDAC = (IUserDAC)dacFactory.Create(DACType.UserDAC);
                    UserDTO resultDTO = userDAC.RegisterUser(userDTO);
                    if (resultDTO != null)
                    {
                        retVal = OperationResult<UserDTO>.CreateSuccessResult(resultDTO);
                    }
                    else
                    {
                        retVal = OperationResult<UserDTO>.CreateFailureResult("Failed!");
                    }
                }
                else
                {
                    retVal = OperationResult<UserDTO>.CreateFailureResult(validationResult);
                }
            }
            catch (DACException dacEx)
            {
                retVal = OperationResult<UserDTO>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                retVal = OperationResult<UserDTO>.CreateErrorResult(ex.Message, ex.StackTrace);
            }

            return retVal;
        }

        public UserDTO GetUserByEmailAndPassword(string Email, string Password)
        {
            IUserDAC userDAC = (IUserDAC)dacFactory.Create(DACType.UserDAC);
            return userDAC.GetUserByEmailAndPassword(Email, Password);
        }
    }
}

