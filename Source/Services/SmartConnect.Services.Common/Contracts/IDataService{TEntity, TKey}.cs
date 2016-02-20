namespace SmartConnect.Services.Common.Contracts
{
    using System.Linq;

    using Data.Models.Contracts;

    /// <summary>
    /// Interface defining full CRUD operations
    /// </summary>
    /// <typeparam name="TEntity">Type of entity</typeparam>
    /// <typeparam name="TKey">Type of entity Id</typeparam>
    public interface IDataService<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
    {
        void Create(TEntity entity);

        IQueryable<TEntity> All();
        
        IQueryable<TEntity> AllWithDeleted();

        void Update(TEntity entity);

        void Delete(TEntity entity);

        void Delete(TKey entityId);

        void HardDelete(TEntity entity);

        void HardDelete(TKey entityId);
    }
}
