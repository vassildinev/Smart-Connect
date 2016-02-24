namespace SmartConnect.Data.Models
{
    using Contracts;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Message : BaseModel<int>
    {
        [Required]
        [MaxLength(2000)]
        public string Text { get; set; }

        [Required]
        public string SenderId { get; set; }

        public virtual User Sender { get; set; }

        [Required]
        public string ReceiverId { get; set; }

        public virtual User Receiver { get; set; }

        public int ContactId { get; set; }

        public virtual Contact Contact { get; set; }

        public DateTime DateSent { get; set; }

        public bool IsSeen { get; set; }
    }
}
