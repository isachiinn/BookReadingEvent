using System.Collections.Generic;

namespace Nagarro.BookReadingEvent.Shared
{
    public interface IBookingEnrollmentBDC : IBusinessDomainComponent
    {
        BookingEnrollmentDTO CreateBooking(BookingEnrollmentDTO bookingEnrollmentDTO);
        List<UserDTO> GetAllUsersOfAEvent(int EventId);
        List<EventDTO> GetAllEventsOfAUser(string Username);
    }
}
