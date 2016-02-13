namespace SmartConnect.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Contracts;

    public class Deal : BaseModel<string>
    {
        private ICollection<Requirement> requirements;
        private ICollection<DealRequest> requests;
        private ICollection<Objective> objectives;

        public Deal()
            : base()
        {
            this.requirements = new HashSet<Requirement>();
            this.requests = new HashSet<DealRequest>();
            this.objectives = new HashSet<Objective>();
        }

        public string Name { get; set; }

        public decimal Value { get; set; }

        public DealStatus Status { get; set; }

        [Required]
        public string ClientId { get; set; }

        public virtual User Client { get; set; }

        public string ExecuterId { get; set; }

        public virtual User Executer { get; set; }

        public virtual ICollection<Requirement> Requirements
        {
            get { return this.requirements; }
            set { this.requirements = value; }
        }

        public virtual ICollection<DealRequest> Requests
        {
            get { return this.requests; }
            set { this.requests = value; }
        }

        public virtual ICollection<Objective> Objectives
        {
            get { return this.objectives; }
            set { this.objectives = value; }
        }
    }
}
