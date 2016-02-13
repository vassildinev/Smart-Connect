namespace SmartConnect.Data.Migrations
{
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    public sealed class Configuration : DbMigrationsConfiguration<SmartConnectDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(SmartConnectDbContext context)
        {
        }

        private void Seed<TEntity>(SmartConnectDbContext context, IEnumerable<TEntity> data)
            where TEntity : class
        {
            var set = context.Set<TEntity>();
            set.AddRange(data);
            context.SaveChanges();
        }
    }
}
