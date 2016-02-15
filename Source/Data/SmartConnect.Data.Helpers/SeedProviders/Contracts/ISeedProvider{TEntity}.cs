namespace SmartConnect.Data.Helpers.SeedProviders.Contracts
{
    using System.Collections.Generic;

    public interface ISeedProvider<TEntity>
    {
        IEnumerable<TEntity> GetSeedData();
    }
}
