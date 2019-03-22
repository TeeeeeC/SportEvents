using SportEvents.Data.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace SportEvents.Data
{
    public interface ISportEventsDbContext
    {
        int SaveChanges();

        void Dispose();

        IDbSet<Event> Events { get; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
