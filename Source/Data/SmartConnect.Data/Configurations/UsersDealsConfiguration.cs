namespace SmartConnect.Data.Configurations
{
    using System.Data.Entity.ModelConfiguration;

    using Models;

    public class UsersDealsConfiguration : EntityTypeConfiguration<Deal>
    {
        public UsersDealsConfiguration()
        {
            this
                .HasRequired(c => c.Client)
                .WithMany(u => u.DealsAsClient)
                .HasForeignKey(c => c.ClientId)
                .WillCascadeOnDelete(false);

            this
                .HasOptional(c => c.Executer)
                .WithMany(u => u.DealsAsExecuter)
                .HasForeignKey(c => c.ExecuterId)
                .WillCascadeOnDelete(false);
        }
    }
}
