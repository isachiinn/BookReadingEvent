using FluentValidation;
using Nagarro.BookReadingEvent.Shared;

namespace Nagarro.BookReadingEvent.Business
{
    public class UserValidator : AbstractValidator<UserDTO>
    {
        public UserValidator()
        {
            RuleFor(dto => dto.Id).NotNull().NotEmpty();
            RuleFor(dto => dto.Email).NotNull().NotEmpty();
            RuleFor(dto => dto.Name).NotNull().NotEmpty();
            RuleFor(dto => dto.Password).NotNull().NotEmpty();

        }
    }
}
