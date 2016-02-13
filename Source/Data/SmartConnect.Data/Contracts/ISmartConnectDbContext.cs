namespace SmartConnect.Data.Contracts
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using Models;

    public interface ISmartConnectDbContext
    {
        IDbSet<User> Users { get; set; }

        IDbSet<Contact> Contacts { get; set; }

        IDbSet<Country> Countries { get; set; }

        IDbSet<Deal> Deals { get; set; }

        IDbSet<DealRequest> DealRequests { get; set; }

        IDbSet<Objective> Objectives { get; set; }

        IDbSet<Quote> Quotes { get; set; }

        IDbSet<Requirement> Requirements { get; set; }
        
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        void Dispose();

        int SaveChanges();
    }
}
