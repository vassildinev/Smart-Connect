namespace SmartConnect.Data.Configurations
{
    using System.Data.Entity.ModelConfiguration;

    using Models;

    public class UsersMessagesConfiguration : EntityTypeConfiguration<Message>
    {
        public UsersMessagesConfiguration()
        {
            this
                .HasRequired(m => m.Sender)
                .WithMany(u => u.MessagesSent)
                .HasForeignKey(m => m.SenderId)
                .WillCascadeOnDelete(false);

            this
                .HasRequired(m => m.Receiver)
                .WithMany(u => u.MessagesReceived)
                .HasForeignKey(m => m.ReceiverId)
                .WillCascadeOnDelete(false);
        }
    }
}
