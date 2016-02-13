namespace SmartConnect.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using Contracts;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using Models.Contracts;

    public class SmartConnectDbContext : IdentityDbContext<User>, ISmartConnectDbContext
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

        public static SmartConnectDbContext Create()
        {
            return new SmartConnectDbContext();
        }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges();
        }

        private void ApplyAuditInfoRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (var entry in
                this.ChangeTracker
                    .Entries()
                    .Where(e =>
                        e.Entity is IAuditInfo &&
                        ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
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
            this.ChangeTableNames(modelBuilder);

            this.RegisterUsersContactsForeignKeyConstraints(modelBuilder);
            this.RegisterUsersDealsForeignKeyConstraints(modelBuilder);
            this.RegisterUsersDealRequestsForeignKeyConstraints(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private void RegisterUsersContactsForeignKeyConstraints(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>()
                    .HasRequired(c => c.Sender)
                    .WithMany(u => u.ContactRequestsSent)
                    .HasForeignKey(c => c.SenderId)
                    .WillCascadeOnDelete(false);

            modelBuilder.Entity<Contact>()
                    .HasRequired(c => c.Receiver)
                    .WithMany(u => u.ContactRequestsReceived)
                    .HasForeignKey(c => c.ReceiverId)
                    .WillCascadeOnDelete(false);
        }

        private void RegisterUsersDealsForeignKeyConstraints(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Deal>()
                    .HasRequired(c => c.Client)
                    .WithMany(u => u.DealsAsClient)
                    .HasForeignKey(c => c.ClientId)
                    .WillCascadeOnDelete(false);

            modelBuilder.Entity<Deal>()
                    .HasRequired(c => c.Executer)
                    .WithMany(u => u.DealsAsExecuter)
                    .HasForeignKey(c => c.ExecuterId)
                    .WillCascadeOnDelete(false);
        }

        private void RegisterUsersDealRequestsForeignKeyConstraints(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DealRequest>()
                    .HasRequired(c => c.Sender)
                    .WithMany(u => u.DealRequestsSent)
                    .HasForeignKey(c => c.SenderId)
                    .WillCascadeOnDelete(false);

            modelBuilder.Entity<DealRequest>()
                    .HasRequired(c => c.Receiver)
                    .WithMany(u => u.DealRequestsReceived)
                    .HasForeignKey(c => c.ReceiverId)
                    .WillCascadeOnDelete(false);
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
