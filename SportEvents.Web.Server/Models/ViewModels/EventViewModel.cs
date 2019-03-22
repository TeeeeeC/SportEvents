using System;

namespace SportEvents.Web.Server.Models.ViewModels
{
    public class EventViewModel
    {
        public int EventID { get; set; }

        public string EventName { get; set; }

        public double? OddsForFirstTeam { get; set; }

        public double? OddsForDraw { get; set; }

        public double? OddsForSecondTeam { get; set; }

        public DateTime EventStartDate { get; set; }
    }
}