using Nagarro.BookReadingEvent.Shared;
using System.Collections.Generic;

namespace Nagarro.BookReadingEvent.Models
{
    public class EventViewModel
    {
        public List<EventDTO> Events
        {
            get;
            set;
        }
        public IEnumerable<EventDTO> BookedEvents
        {
            get;
            set;
        }
    }
}