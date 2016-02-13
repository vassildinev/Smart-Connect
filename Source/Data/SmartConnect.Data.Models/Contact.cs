namespace SmartConnect.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Contracts;

    public class Contact : BaseModel<string>
    {
        [Required]
        public string SenderId { get; set; }

        public virtual User Sender { get; set; }

        [Required]
        public string ReceiverId { get; set; }

        public virtual User Receiver { get; set; }

        public bool Confirmed { get; set; }
    }
}
