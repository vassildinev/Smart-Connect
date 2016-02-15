namespace SmartConnect.Services.Cache
{
    using System;
    using System.Web;
    using System.Web.Caching;

    using Contracts;

    public class HttpCacheService : ICacheService
    {
        private static readonly object LockObject = new object();

        public TEntity Get<TEntity>(string itemName, Func<TEntity> getDataFunc, int durationInSeconds)
            where TEntity: class
        {
            if (HttpRuntime.Cache[itemName] == null)
            {
                lock (LockObject)
                {
                    if (HttpRuntime.Cache[itemName] == null)
                    {
                        var data = getDataFunc();
                        HttpRuntime.Cache.Insert(
                            itemName,
                            data,
                            null,
                            DateTime.Now.AddSeconds(durationInSeconds),
                            Cache.NoSlidingExpiration);
                    }
                }
            }

            return HttpRuntime.Cache[itemName] as TEntity;
        }

        public void Remove(string itemName)
        {
            HttpRuntime.Cache.Remove(itemName);
        }
    }
}
