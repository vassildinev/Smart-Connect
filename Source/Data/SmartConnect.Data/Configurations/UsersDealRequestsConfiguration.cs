namespace SmartConnect.Data.Configurations
{
    using System.Data.Entity.ModelConfiguration;

    using Models;

    public class UsersDealRequestsConfiguration : EntityTypeConfiguration<DealRequest>
    {
        public UsersDealRequestsConfiguration()
        {
            this
                .HasRequired(c => c.Sender)
                .WithMany(u => u.DealRequestsSent)
                .HasForeignKey(c => c.SenderId)
                .WillCascadeOnDelete(false);

            this
                .HasRequired(c => c.Receiver)
                .WithMany(u => u.DealRequestsReceived)
                .HasForeignKey(c => c.ReceiverId)
                .WillCascadeOnDelete(false);
        }
    }
}
