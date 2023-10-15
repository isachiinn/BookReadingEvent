using Nagarro.BookReadingEvent.EntityDataModel;
using Nagarro.BookReadingEvent.Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nagarro.BookReadingEvent.Data
{
    public class BookingEnrollmentDAC : DACBase, IBookingEnrollmentDAC
    {
        public BookingEnrollmentDAC()
           : base(DACType.BookingEnrollmentDAC)
        {

        }

        public BookingEnrollmentDTO CreateBooking(BookingEnrollmentDTO bookingEnrollmentDTO)
        {
            BookingEnrollmentDTO retVal = null;
            try
            {
                using (BookReadingEventEntities bookingContext = new BookReadingEventEntities())
                {
                    bookingContext.Database.Log = Logger.Log;
                    BookingEnrollment bookingEnrollment = new BookingEnrollment();

                    EntityConverter.FillEntityFromDTO(bookingEnrollmentDTO, bookingEnrollment);

                    bool flag = false;

                    var bookings = bookingContext.BookingEnrollments.Where(booking => booking.EventsId == bookingEnrollmentDTO.EventsId).Where(booking => booking.Username == bookingEnrollmentDTO.Username).Select(booking => booking);
                    foreach (var booking in bookings)
                    {

                        bookingEnrollmentDTO.Id = booking.Id;
                        flag = true;
                    }
                    if (flag == false)
                    {
                        bookingContext.BookingEnrollments.Add(bookingEnrollment);
                        try
                        {
                            bookingContext.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            ExceptionManager.HandleException(ex);
                            throw new DACException(ex.Message, ex);
                        }


                    }


                    EntityConverter.FillDTOFromEntity(bookingEnrollment, bookingEnrollmentDTO);
                    retVal = bookingEnrollmentDTO;
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DACException(ex.Message, ex);
            }

            return retVal;
        }

        public List<EventDTO> GetAllEventsOfAUser(string Username)
        {
            List<int> EventIdList = new List<int>();
            List<EventDTO> EventList = new List<EventDTO>();
            AddressDTO addressDTO = new AddressDTO();

            using (var bookingEnrollmentContext = new BookReadingEventEntities())
            {
                bookingEnrollmentContext.Database.Log = Logger.Log;
                foreach (var i in bookingEnrollmentContext.BookingEnrollments)
                {
                    if (i.Username == Username)
                        EventIdList.Add((int)i.EventsId);
                }

                foreach (var eventId in EventIdList)
                {
                    EventDTO eventDTO = new EventDTO();
                    var Event = bookingEnrollmentContext.Events.Include("Address").FirstOrDefault(ev => ev.Id == eventId);
                    if (Event != null)
                    {
                        EntityConverter.FillDTOFromEntity(Event.Address, addressDTO);
                        eventDTO.Address = addressDTO;
                        EntityConverter.FillDTOFromEntity(Event, eventDTO);
                    }
                    EventList.Add(eventDTO);
                }


            }

            return EventList;
        }

        public List<UserDTO> GetAllUsersOfAEvent(int EventId)
        {
            List<string> UsernameList = new List<string>();
            List<UserDTO> UserList = new List<UserDTO>();
            using (var bookingEnrollmentContext = new BookReadingEventEntities())
            {
                bookingEnrollmentContext.Database.Log = Logger.Log;
                foreach (var i in bookingEnrollmentContext.BookingEnrollments)
                {
                    if (i.EventsId == EventId)
                        UsernameList.Add(i.Username);
                }

                foreach (var Username in UsernameList)
                {
                    UserDTO userDTO = new UserDTO();
                    var User = bookingEnrollmentContext.Users.FirstOrDefault(user => user.Username == Username.Trim());
                    if (User != null && User.Id != -1)
                    {
                        EntityConverter.FillDTOFromEntity(User, userDTO);
                        UserList.Add(userDTO);
                    }

                }

            }
            return UserList;
        }




    }
}
