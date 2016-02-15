namespace SmartConnect.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Contracts;

    public class DealRequest : BaseModel<int>
    {
        [MaxLength(300)]
        public string Comment { get; set; }

        public string SenderId { get; set; }

        public virtual User Sender { get; set; }

        public string ReceiverId { get; set; }

        public virtual User Receiver { get; set; }

        public int DealId { get; set; }

        public virtual Deal Deal { get; set; }

        public bool IsConfirmed { get; set; }
    }
}
