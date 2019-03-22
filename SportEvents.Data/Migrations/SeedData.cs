using SportEvents.Data.Models;
using System;

namespace SportEvents.Data.Migrations
{
    public class SeedData
    {
        private ISportEventsDbContext context;

        public SeedData()
        {
            this.context = new SportEventsDbContext();
        }

        public void Seed()
        {
            this.context.Events.Add(new Event()
            {
                EventName = "Liverpool - Juventus",
                OddsForDraw = 3.15,
                OddsForFirstTeam = 1.95,
                OddsForSecondTeam = 2.2,
                EventStartDate = DateTime.UtcNow.AddDays(1)
            });
            this.context.Events.Add(new Event()
            {
                EventName = "Grigor Dimitrov - Rafael Nadal",
                OddsForDraw = 3.05,
                OddsForFirstTeam = 2,
                OddsForSecondTeam = 2.7,
                EventStartDate = DateTime.UtcNow.AddDays(2)
            });
            this.context.Events.Add(new Event()
            {
                EventName = "Barcelona - Ludogorets",
                OddsForDraw = 4.2,
                OddsForFirstTeam = 1.01,
                OddsForSecondTeam = 15.2,
                EventStartDate = DateTime.UtcNow.AddDays(-1)
            });

            this.context.SaveChanges();
        }
    }
}
