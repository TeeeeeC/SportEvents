using SportEvents.Services;
using SportEvents.Services.DTOs;
using SportEvents.Web.Server.Models.InputModels;
using SportEvents.Web.Server.Models.ViewModels;
using System.Collections.Generic;
using System.Web.Http;

namespace SportEvents.Web.Server.Controllers
{
    public class EventsController : ApiController
    {
        private readonly IEventService eventService;

        public EventsController(IEventService eventService)
        {
            this.eventService = eventService;
        }

        public IHttpActionResult GetEvents()
        {
            var eventsDTO = this.eventService.GetEvents();
            var eventsModel = this.MapToEventViewModel(eventsDTO);

            return this.Ok(eventsModel);
        }

        [HttpPost]
        [Route("api/events/addEvent")]
        public IHttpActionResult AddEvent()
        {
            var eventItem = this.eventService.AddEvent();

            return this.Ok(eventItem);
        }

        [HttpPost]
        [Route("api/events/deleteEvent")]
        public IHttpActionResult DeleteEvent([FromBody]int eventID)
        {
            this.eventService.DeleteEvent(eventID);

            return this.Ok();
        }

        [HttpPost]
        [Route("api/events/updateEvent")]
        public IHttpActionResult UpdateEvent(EventInputModel eventItem)
        {
            if (this.ModelState.IsValid)
            {
                var eventDTO = new EventDTO()
                {
                    EventID = eventItem.EventID,
                    EventName = eventItem.EventName,
                    EventStartDate = eventItem.EventStartDate,
                    OddsForDraw = eventItem.OddsForDraw,
                    OddsForFirstTeam = eventItem.OddsForFirstTeam,
                    OddsForSecondTeam = eventItem.OddsForSecondTeam
                };

                this.eventService.UpdateEvent(eventDTO);

                return this.Ok();
            }

            return this.BadRequest(this.ModelState);
        }

        private IList<EventViewModel> MapToEventViewModel(IList<EventDTO> events)
        {
            var eventsViewModel = new List<EventViewModel>();
            foreach (var eventItem in events)
            {
                eventsViewModel.Add(new EventViewModel()
                {
                    EventID = eventItem.EventID,
                    EventName = eventItem.EventName,
                    EventStartDate = eventItem.EventStartDate,
                    OddsForDraw = eventItem.OddsForDraw,
                    OddsForFirstTeam = eventItem.OddsForFirstTeam,
                    OddsForSecondTeam = eventItem.OddsForSecondTeam
                });
            }

            return eventsViewModel;
        }
    }
}
