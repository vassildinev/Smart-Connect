namespace SmartConnect.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Contracts;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class User : IdentityUser, IEntity<string>
    {
        private ICollection<Deal> dealsAsClient;
        private ICollection<Deal> dealsAsExecuter;
        private ICollection<DealRequest> dealRequestsSent;
        private ICollection<DealRequest> dealRequestsReceived;
        private ICollection<Contact> contactRequestsSent;
        private ICollection<Contact> contactRequestsReceived;
        private ICollection<Objective> objectives;
        private ICollection<Team> teams;

        public User()
            : base ()
        {
            this.dealsAsClient = new HashSet<Deal>();
            this.dealsAsExecuter = new HashSet<Deal>();
            this.dealRequestsSent = new HashSet<DealRequest>();
            this.dealRequestsReceived = new HashSet<DealRequest>();
            this.contactRequestsSent = new HashSet<Contact>();
            this.contactRequestsReceived = new HashSet<Contact>();
            this.objectives = new HashSet<Objective>();
            this.teams = new HashSet<Team>();
            this.CreatedOn = DateTime.Now;
        }

        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        [Column(TypeName = "Date")]
        public DateTime? DateOfBirth { get; set; }

        public Gender Gender { get; set; }

        public int? CountryId { get; set; }

        public Country Country { get; set; }

        [Column(TypeName = "Date")]
        public DateTime CreatedOn { get; set; }

        [Column(TypeName = "Date")]
        public DateTime? DeletedOn { get; set; }

        public bool IsDeleted { get; set; }

        [Column(TypeName = "Date")]
        public DateTime? ModifiedOn { get; set; }

        public ICollection<Deal> DealsAsClient
        {
            get { return this.dealsAsClient; }
            set { this.dealsAsClient = value; }
        }

        public ICollection<Deal> DealsAsExecuter
        {
            get { return this.dealsAsExecuter; }
            set { this.dealsAsExecuter = value; }
        }

        public ICollection<DealRequest> DealRequestsSent
        {
            get { return this.dealRequestsSent; }
            set { this.dealRequestsSent = value; }
        }

        public ICollection<DealRequest> DealRequestsReceived
        {
            get { return this.dealRequestsReceived; }
            set { this.dealRequestsReceived = value; }
        }

        public ICollection<Contact> ContactRequestsSent
        {
            get { return this.contactRequestsSent; }
            set { this.contactRequestsSent = value; }
        }

        public ICollection<Contact> ContactRequestsReceived
        {
            get { return this.contactRequestsReceived; }
            set { this.contactRequestsReceived = value; }
        }

        public ICollection<Objective> Objectives
        {
            get { return this.objectives; }
            set { this.objectives = value; }
        }

        public ICollection<Team> Teams
        {
            get { return this.teams; }
            set { this.teams = value; }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            ClaimsIdentity userIdentity = await manager
                .CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
    }
}
