using System.Collections.Generic;

namespace Nagarro.BookReadingEvent.Shared
{
    public interface IBookingEnrollmentFacade : IFacade
    {
        BookingEnrollmentDTO CreateBooking(BookingEnrollmentDTO bookingEnrollmentDTO);
        List<UserDTO> GetAllUsersOfAEvent(int EventId);
        List<EventDTO> GetAllEventsOfAUser(string Username);
    }
}
