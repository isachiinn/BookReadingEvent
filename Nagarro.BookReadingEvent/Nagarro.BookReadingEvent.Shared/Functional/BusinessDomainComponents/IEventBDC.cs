using System.Collections.Generic;

namespace Nagarro.BookReadingEvent.Shared
{
    public interface IEventBDC : IBusinessDomainComponent
    {
        OperationResult<EventDTO> CreateEvent(EventDTO EventDTO);
        List<EventDTO> GetAllEvents();
        EventDTO GetEventById(int EventId);
        bool UpdateEvent(EventDTO EventDTO);
        bool DeleteEvent(EventDTO eventDTO);

    }
}
