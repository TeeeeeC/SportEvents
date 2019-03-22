using Ninject.Modules;
using SportEvents.Data;
using SportEvents.Data.Migrations;
using SportEvents.Data.Repositories;
using System.Data.Entity;

namespace SportEvents.Services.IoC
{
    public class DataAccessDependency : NinjectModule
    {
        public override void Load()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SportEventsDbContext, Configuration>());

            Bind<ISportEventsDbContext>().To<SportEventsDbContext>().InSingletonScope();
            Bind(typeof(IRepository<>)).To(typeof(GenericRepository<>));
        }
    }
}
