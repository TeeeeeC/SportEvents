using SportEvents.Data.Models;
using System.Data.Entity;

namespace SportEvents.Data
{
    public class SportEventsDbContext : DbContext, ISportEventsDbContext
    {
        public SportEventsDbContext()
            : base("SportEvents")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public virtual IDbSet<Event> Events { get; set; }
    }
}
