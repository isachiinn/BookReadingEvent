using Nagarro.BookReadingEvent.Shared;
using System.Collections.Generic;

namespace Nagarro.BookReadingEvent.BusinessFacades
{
    public class BookingEnrollmentFacade : FacadeBase, IBookingEnrollmentFacade
    {
        public BookingEnrollmentFacade()
            : base(FacadeType.BookingEnrollment)
        {

        }

        public BookingEnrollmentDTO CreateBooking(BookingEnrollmentDTO bookingEnrollmentDTO)
        {
            IBookingEnrollmentBDC bookingBDC = (IBookingEnrollmentBDC)BDCFactory.Instance.Create(BDCType.BookingEnrollmentBDC);
            return bookingBDC.CreateBooking(bookingEnrollmentDTO);
        }


        public List<EventDTO> GetAllEventsOfAUser(string Username)
        {
            IBookingEnrollmentBDC bookingBDC = (IBookingEnrollmentBDC)BDCFactory.Instance.Create(BDCType.BookingEnrollmentBDC);
            return bookingBDC.GetAllEventsOfAUser(Username);
        }

        public List<UserDTO> GetAllUsersOfAEvent(int EventId)
        {
            IBookingEnrollmentBDC bookingBDC = (IBookingEnrollmentBDC)BDCFactory.Instance.Create(BDCType.BookingEnrollmentBDC);
            return bookingBDC.GetAllUsersOfAEvent(EventId);
        }

    }
}
