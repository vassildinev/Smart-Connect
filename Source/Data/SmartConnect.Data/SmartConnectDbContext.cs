namespace SmartConnect.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;

    using Configurations;
    using Contracts;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using Models.Contracts;

    public class SmartConnectDbContext : IdentityDbContext<User>, ISmartConnectDbContext, IDisposable, IObjectContextAdapter
    {
        private const string DbConnectionName = "SmartConnection";

        public SmartConnectDbContext()
            : base(DbConnectionName, throwIfV1Schema: false)
        {
        }

        public IDbSet<Contact> Contacts { get; set; }

        public IDbSet<Country> Countries { get; set; }

        public IDbSet<Deal> Deals { get; set; }

        public IDbSet<DealRequest> DealRequests { get; set; }

        public IDbSet<Objective> Objectives { get; set; }

        public IDbSet<Quote> Quotes { get; set; }

        public IDbSet<Requirement> Requirements { get; set; }
        
        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges();
        }

        private void ApplyAuditInfoRules()
        {
            Func<DbEntityEntry, bool> changeTrackerCondition = 
                e => e.Entity is IAuditInfo &&
                     ((e.State == EntityState.Added) || (e.State == EntityState.Modified));
            
            foreach (var entry in this.ChangeTracker.Entries().Where(changeTrackerCondition))
            {
                var entity = (IAuditInfo)entry.Entity;
                if (entry.State == EntityState.Added && entity.CreatedOn == default(DateTime))
                {
                    entity.CreatedOn = DateTime.Now;
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UsersContactsConfiguration());
            modelBuilder.Configurations.Add(new UsersDealsConfiguration());
            modelBuilder.Configurations.Add(new UsersDealRequestsConfiguration());

            base.OnModelCreating(modelBuilder);

            this.ChangeTableNames(modelBuilder);
        }

        private void ChangeTableNames(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<IdentityUserRole>().ToTable("Permissions");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogins");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaims");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles");
        }
    }
}
