using System;

namespace SportEvents.Services.DTOs
{
    public class EventDTO
    {
        public int EventID { get; set; }

        public string EventName { get; set; }

        public double? OddsForFirstTeam { get; set; }

        public double? OddsForDraw { get; set; }

        public double? OddsForSecondTeam { get; set; }

        public DateTime EventStartDate { get; set; }
    }
}
