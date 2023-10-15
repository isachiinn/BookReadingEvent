using FluentValidation;
using Nagarro.BookReadingEvent.Shared;

namespace Nagarro.BookReadingEvent.Business
{

    public class EventValidator : AbstractValidator<EventDTO>
    {
        public EventValidator()
        {

            RuleFor(dto => dto.Title).NotNull().NotEmpty();
            RuleFor(dto => dto.Date).NotNull().NotEmpty();
            RuleFor(dto => dto.Address.Venue).NotNull().NotEmpty();
            RuleFor(dto => dto.Address.City).NotNull().NotEmpty();
            RuleFor(dto => dto.Address.State).NotNull().NotEmpty();
            RuleFor(dto => dto.StartTime).NotNull().NotEmpty();
            RuleFor(dto => dto.Duration).LessThan(5);
            RuleFor(dto => dto.Description).MaximumLength(50);
            RuleFor(dto => dto.OtherDetails).MaximumLength(500);
            RuleFor(dto => dto.Invitations).MaximumLength(5000);

        }
    }

}
