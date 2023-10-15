using System.Collections.Generic;

namespace Nagarro.BookReadingEvent.Shared
{
    public interface IBookingEnrollmentDAC : IDataAccessComponent
    {
        BookingEnrollmentDTO CreateBooking(BookingEnrollmentDTO bookingEnrollmentDTO);
        List<UserDTO> GetAllUsersOfAEvent(int EventId);
        List<EventDTO> GetAllEventsOfAUser(string Username);
    }
}
