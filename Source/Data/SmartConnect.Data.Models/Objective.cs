namespace SmartConnect.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Contracts;

    public class Objective : BaseModel<string>
    {
        [Required]
        public string ResponsibleUserId { get; set; }

        public virtual User ResponsibleUser { get; set; }

        public string DealId { get; set; }

        public Deal Deal { get; set; }

        public DateTime Deadline { get; set; }

        public ObjectiveStatus Status {get;set; }
    }
}
