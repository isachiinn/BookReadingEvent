using Nagarro.BookReadingEvent.Shared;
using System.Collections.Generic;

namespace Nagarro.BookReadingEvent.BusinessFacades
{
    public class EventFacade : FacadeBase, IEventFacade
    {
        public EventFacade()
            : base(FacadeType.EventFacade)
        {

        }

        public OperationResult<EventDTO> CreateEvent(EventDTO eventDTO)
        {
            IEventBDC eventBDC = (IEventBDC)BDCFactory.Instance.Create(BDCType.EventBDC);
            return eventBDC.CreateEvent(eventDTO);
        }

        public bool DeleteEvent(EventDTO eventDTO)
        {
            IEventBDC eventBDC = (IEventBDC)BDCFactory.Instance.Create(BDCType.EventBDC);
            return eventBDC.DeleteEvent(eventDTO);
        }

        public EventDTO GetEventById(int EventId)
        {
            IEventBDC eventBDC = (IEventBDC)BDCFactory.Instance.Create(BDCType.EventBDC);
            return eventBDC.GetEventById(EventId);
        }



        public List<EventDTO> GetAllEvents()
        {
            IEventBDC eventBDC = (IEventBDC)BDCFactory.Instance.Create(BDCType.EventBDC);
            List<EventDTO> result = eventBDC.GetAllEvents();
            return result;
        }

        public bool UpdateEvent(EventDTO EventDTO)
        {
            IEventBDC eventBDC = (IEventBDC)BDCFactory.Instance.Create(BDCType.EventBDC);
            return eventBDC.UpdateEvent(EventDTO);
        }
    }
}
