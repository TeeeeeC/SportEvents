namespace SportEvents.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<SportEventsDbContext>
    {
        private SeedData data;

        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = false;
            this.data = new SeedData();
        }

        protected override void Seed(SportEventsDbContext context)
        {
            if (context.Events.Any())
            {
                return;
            }

            this.data.Seed();
        }
    }
}
