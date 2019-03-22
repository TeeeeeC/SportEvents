using System;
using System.Collections.Generic;
using System.Linq;
using SportEvents.Data.Models;
using SportEvents.Data.Repositories;
using SportEvents.Services.DTOs;
using SportEvents.Services.Utils;

namespace SportEvents.Services
{
    public class EventService : IEventService
    {
        private readonly IRepository<Event> eventsRepository;

        public EventService(IRepository<Event> eventsRepository)
        {
            this.eventsRepository = eventsRepository;
        }

        public IList<EventDTO> GetEvents()
        {
            var eventsDb = this.eventsRepository.All()
                .OrderByDescending(e => e.EventStartDate)
                .Skip(0)
                .Take(100)
                .ToList();

            return this.MapEventToDTO(eventsDb);
        }

        public EventDTO AddEvent()
        {
            var eventItem = new Event()
            {
                EventStartDate = DateTimeExtentions.EndOfDateTime(new DateTime())
            };

            this.eventsRepository.Add(eventItem);
            this.eventsRepository.SaveChanges();

            return new EventDTO()
            {
                EventID = eventItem.EventID,
                EventStartDate = eventItem.EventStartDate
            };
        }

        public void DeleteEvent(int eventID)
        {
            var eventDb = this.eventsRepository.All().FirstOrDefault(e => e.EventID == eventID);
            this.eventsRepository.Delete(eventDb);
            this.eventsRepository.SaveChanges();
        }

        public void UpdateEvent(EventDTO eventItem)
        {
            var eventDb = this.eventsRepository.All().FirstOrDefault(e => e.EventID == eventItem.EventID);

            eventDb.EventName = eventItem.EventName;
            eventDb.OddsForDraw = eventItem.OddsForDraw;
            eventDb.OddsForFirstTeam = eventItem.OddsForFirstTeam;
            eventDb.OddsForSecondTeam = eventItem.OddsForSecondTeam;
            eventDb.EventStartDate = eventItem.EventStartDate;

            this.eventsRepository.Update(eventDb);
            this.eventsRepository.SaveChanges();
        }

        private IList<EventDTO> MapEventToDTO(IList<Event> eventsDB)
        {
            var eventsDTO = new List<EventDTO>();
            foreach (var eventItem in eventsDB)
            {
                eventsDTO.Add(new EventDTO()
                {
                    EventID = eventItem.EventID,
                    EventName = eventItem.EventName,
                    EventStartDate = eventItem.EventStartDate,
                    OddsForDraw = eventItem.OddsForDraw,
                    OddsForFirstTeam = eventItem.OddsForFirstTeam,
                    OddsForSecondTeam = eventItem.OddsForSecondTeam
                });
            }

            return eventsDTO;
        }
    }
}
