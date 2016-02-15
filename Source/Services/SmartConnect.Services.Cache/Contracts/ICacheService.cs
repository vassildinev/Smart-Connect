namespace SmartConnect.Services.Cache.Contracts
{
    using System;

    public interface ICacheService
    {
        TEntity Get<TEntity>(string itemName, Func<TEntity> getDataFunc, int durationInSeconds)
            where TEntity : class;

        void Remove(string itemName);
    }
}
