namespace SmartConnect.Data.Repositories.Contracts
{
    using System.Linq;

    using Models.Contracts;
    using System;

    public interface IRepository<TEntity, TKey> 
        where TEntity : class, IEntity<TKey>
        where TKey : struct
    {
        IQueryable<TEntity> All();

        IQueryable<TEntity> AllWithDeleted();

        TEntity GetById(TKey id);

        void Add(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        void Delete(TKey id);

        void HardDelete(TEntity entity);

        void HardDelete(TKey id);

        TEntity Attach(TEntity entity);

        void Detach(TEntity entity);

        int SaveChanges();
    }
}
