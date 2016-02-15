namespace SmartConnect.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Contracts;

    public class Requirement : BaseModel<int>
    {
        private ICollection<Deal> deals;

        public Requirement()
        {
            this.deals = new HashSet<Deal>();
        }

        [Required]
        [MaxLength(150)]
        public string Name { get; set; }

        public bool IsFulfilled { get; set; }

        public RequirementPriority Priority { get; set; }

        public ICollection<Deal> Deals
        {
            get { return this.deals; }
            set { this.deals = value; }
        }
    }
}