namespace SmartConnect.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Contracts;

    public class Requirement : BaseModel<int>
    {
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }

        public bool IsFulfilled { get; set; }

        public RequirementPriority Priority { get; set; }

        [Required]
        public int DealId { get; set; }

        public virtual Deal Deal { get; set; }
    }
}