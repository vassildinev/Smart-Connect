namespace SmartConnect.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Contracts;
    using System.Collections.Generic;

    public class Contact : BaseModel<int>
    {
        private ICollection<Message> messages;

        public Contact()
        {
            this.messages = new HashSet<Message>();
        }

        [Required]
        public string SenderId { get; set; }

        public virtual User Sender { get; set; }

        [Required]
        public string ReceiverId { get; set; }

        public virtual User Receiver { get; set; }

        public bool Confirmed { get; set; }

        public virtual ICollection<Message> Messages
        {
            get { return this.messages; }
            set { this.messages = value; }
        }
    }
}
