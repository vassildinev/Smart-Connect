namespace SmartConnect.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    public class SmartConnectDbContext : IdentityDbContext<User>
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
