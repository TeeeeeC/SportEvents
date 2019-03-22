using SportEvents.Services.DTOs;
using System.Collections.Generic;

namespace SportEvents.Services
{
    public interface IEventService
    {
        IList<EventDTO> GetEvents();

        EventDTO AddEvent();

        void DeleteEvent(int eventID);

        void UpdateEvent(EventDTO eventItem);
    }
}
