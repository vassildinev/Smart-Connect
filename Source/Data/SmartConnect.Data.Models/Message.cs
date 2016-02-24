namespace SmartConnect.Data.Models
{
    using Contracts;
    using System.ComponentModel.DataAnnotations;

    public class Message : BaseModel<int>
    {
        [Required]
        [MaxLength(2000)]
        public string Text { get; set; }

        [Required]
        public string SenderId { get; set; }

        public User Sender { get; set; }

        [Required]
        public string ReceiverId { get; set; }

        public User Receiver { get; set; }

        public bool IsSeen { get; set; }
    }
}
