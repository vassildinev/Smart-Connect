namespace SmartConnect.Data.Models
{
    using Contracts;

    public class DealRequest : BaseModel<string>
    {
        public string SenderId { get; set; }

        public virtual User Sender { get; set; }

        public string ReceiverId { get; set; }

        public User Receiver { get; set; }

        public string DealId { get; set; }

        public virtual Deal Deal { get; set; }

        public bool IsConfirmed { get; set; }
    }
}
