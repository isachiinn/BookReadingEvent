using Nagarro.BookReadingEvent.EntityDataModel;
using Nagarro.BookReadingEvent.Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nagarro.BookReadingEvent.Data
{
    public class EventDAC : DACBase, IEventDAC
    {
        public EventDAC()
            : base(DACType.EventDAC)
        {

        }

        public EventDTO CreateEvent(EventDTO eventDTO)
        {
            EventDTO retVal = null;
            try
            {
                using (BookReadingEventEntities eventContext = new BookReadingEventEntities())
                {
                    eventContext.Database.Log = Logger.Log;
                    Event e = new Event();
                    Address address = new Address();

                    address = eventContext.Addresses.FirstOrDefault(x => x.Venue == eventDTO.Address.Venue &&
                    x.City == eventDTO.Address.City &&
                    x.State == eventDTO.Address.State);
                    if (address == null)
                    {
                        EntityConverter.FillEntityFromDTO(eventDTO.Address, address);
                        address = eventContext.Addresses.Add(address);
                        eventContext.SaveChanges();
                        eventDTO.AddressId = address.Id;
                        //ModelState.Clear();
                    }
                    else
                    {
                        eventDTO.AddressId = address.Id;
                    }



                    EntityConverter.FillEntityFromDTO(eventDTO, e);
                    e.Address = address;
                    //e.AddressId = address.Id;

                    eventContext.Events.Add(e);
                    try
                    {
                        eventContext.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        ExceptionManager.HandleException(ex);
                        throw new DACException(ex.Message, ex);
                    }

                    EntityConverter.FillDTOFromEntity(e, eventDTO);
                    retVal = eventDTO;
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DACException(ex.Message, ex);
            }

            return retVal;
        }

        public List<EventDTO> GetAllEvents()
        {
            using (var eventContext = new BookReadingEventEntities())
            {
                eventContext.Database.Log = Logger.Log;
                List<EventDTO> eventList = new List<EventDTO>();
                foreach (var e in eventContext.Events)
                {
                    EventDTO eventDTO = new EventDTO();
                    EntityConverter.FillDTOFromEntity(e, eventDTO);
                    eventList.Add(eventDTO);
                }
                return eventList;
            }
        }

        public EventDTO GetEventById(int EventId)
        {
            EventDTO eventDTO = new EventDTO();
            AddressDTO addressDTO = new AddressDTO();
            using (var eventContext = new BookReadingEventEntities())
            {
                eventContext.Database.Log = Logger.Log;
                var result = eventContext.Events.Include("Address").FirstOrDefault(ev => ev.Id == EventId);
                if (result != null)
                {
                    EntityConverter.FillDTOFromEntity(result.Address, addressDTO);
                    eventDTO.Address = addressDTO;
                    EntityConverter.FillDTOFromEntity(result, eventDTO);
                }
            }
            return eventDTO;
        }

        public bool UpdateEvent(EventDTO eventDTO)
        {
            using (BookReadingEventEntities eventContext = new BookReadingEventEntities())
            {
                eventContext.Database.Log = Logger.Log;
                Event e = eventContext.Events.Include("Address").SingleOrDefault(ev => ev.Id == eventDTO.Id);

                if (e != null)
                {

                    foreach (var i in eventContext.Addresses)
                    {
                        if (i.Id == eventDTO.AddressId)
                        {

                            i.Venue = eventDTO.Address.Venue;
                            i.City = eventDTO.Address.City;
                            i.State = eventDTO.Address.State;
                        }
                    }

                    EntityConverter.FillEntityFromDTO(eventDTO, e);

                    try
                    {

                        eventContext.SaveChanges();
                    }
                    catch
                    {
                        return false;
                    }
                }

            }
            return true;
        }

        public bool DeleteEvent(EventDTO eventDTO)
        {
            using (BookReadingEventEntities eventContext = new BookReadingEventEntities())
            {
                eventContext.Database.Log = Logger.Log;
                Event e = eventContext.Events.SingleOrDefault(ev => ev.Id == eventDTO.Id);
                var comments = eventContext.Comments.Where(comment => comment.EventId == eventDTO.Id).Select(comment => comment);
                var bookings = eventContext.BookingEnrollments.Where(booking => booking.EventsId == eventDTO.Id).Select(booking => booking);

                if (e != null)
                {
                    eventContext.Events.Remove(e);
                    foreach (var i in comments)
                        eventContext.Comments.Remove(i);
                    foreach (var i in bookings)
                        eventContext.BookingEnrollments.Remove(i);
                    try
                    {
                        eventContext.SaveChanges();
                    }
                    catch
                    {
                        return false;

                    }

                }

            }
            return true;
        }

    }

}






