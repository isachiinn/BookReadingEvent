using Nagarro.BookReadingEvent.Shared;
using System.Collections.Generic;

namespace Nagarro.BookReadingEvent.Business
{
    public class BookingEnrollmentBDC : BDCBase, IBookingEnrollmentBDC
    {
        private readonly IDACFactory dacFactory;

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        public BookingEnrollmentBDC()
            : base(BDCType.BookingEnrollmentBDC)
        {
            dacFactory = DACFactory.Instance;
        }

        public BookingEnrollmentBDC(IDACFactory dacFactory)
            : base(BDCType.BookingEnrollmentBDC)
        {
            this.dacFactory = dacFactory;
        }

        public BookingEnrollmentDTO CreateBooking(BookingEnrollmentDTO bookingEnrollmentDTO)
        {
            IBookingEnrollmentDAC bookingDAC = (IBookingEnrollmentDAC)dacFactory.Create(DACType.BookingEnrollmentDAC);
            return bookingDAC.CreateBooking(bookingEnrollmentDTO);
        }
        #endregion





        public List<EventDTO> GetAllEventsOfAUser(string Username)
        {
            IBookingEnrollmentDAC bookingDAC = (IBookingEnrollmentDAC)dacFactory.Create(DACType.BookingEnrollmentDAC);
            return bookingDAC.GetAllEventsOfAUser(Username);
        }

        public List<UserDTO> GetAllUsersOfAEvent(int EventId)
        {
            IBookingEnrollmentDAC bookingDAC = (IBookingEnrollmentDAC)dacFactory.Create(DACType.BookingEnrollmentDAC);
            return bookingDAC.GetAllUsersOfAEvent(EventId);
        }

    }
}
