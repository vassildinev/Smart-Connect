namespace SmartConnect.Data
{
    using Contracts;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    public class SmartConnectDbContext : IdentityDbContext<User>, ISmartConnectDbContext
    {
        private const string DbConnectionName = "SmartConnection";

        public SmartConnectDbContext()
            : base(DbConnectionName, throwIfV1Schema: false)
        {
        }

        public static SmartConnectDbContext Create()
        {
            return new SmartConnectDbContext();
        }
    }
}
