using FluentValidation;
using Nagarro.BookReadingEvent.Shared;

namespace Nagarro.BookReadingEvent.Business
{
    public class CommentValidator : AbstractValidator<CommentDTO>
    {
        public CommentValidator()
        {
            RuleFor(dto => dto.Id).NotNull().NotEmpty();
            RuleFor(dto => dto.Comment1).NotNull().NotEmpty();
        }
    }
}
