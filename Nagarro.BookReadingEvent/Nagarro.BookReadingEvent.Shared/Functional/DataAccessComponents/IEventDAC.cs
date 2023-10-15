using System.Collections.Generic;

namespace Nagarro.BookReadingEvent.Shared
{
    public interface IEventDAC : IDataAccessComponent
    {
        EventDTO CreateEvent(EventDTO EventDTO);
        List<EventDTO> GetAllEvents();
        EventDTO GetEventById(int EventId);
        bool UpdateEvent(EventDTO EventDTO);
        bool DeleteEvent(EventDTO eventDTO);
    }
}
