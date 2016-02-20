namespace SmartConnect.Data.Configurations
{
    using System.Data.Entity.ModelConfiguration;

    using Models;

    public class UsersContactsConfiguration : EntityTypeConfiguration<Contact>
    {
        public UsersContactsConfiguration()
        {
            this
                .HasRequired(c => c.Sender)
                .WithMany(u => u.ContactRequestsSent)
                .HasForeignKey(c => c.SenderId)
                .WillCascadeOnDelete(false);

            this
                .HasRequired(c => c.Receiver)
                .WithMany(u => u.ContactRequestsReceived)
                .HasForeignKey(c => c.ReceiverId)
                .WillCascadeOnDelete(false);
        }
    }
}
