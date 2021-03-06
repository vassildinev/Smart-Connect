﻿namespace SmartConnect.Data.Models
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
        private ICollection<Message> messagesSent;
        private ICollection<Message> messagesReceived;

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
            this.messagesSent = new HashSet<Message>();
            this.messagesReceived = new HashSet<Message>();
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

        public virtual Country Country { get; set; }

        [Column(TypeName = "Datetime")]
        public DateTime CreatedOn { get; set; }

        [Column(TypeName = "Datetime")]
        public DateTime? DeletedOn { get; set; }

        public bool IsDeleted { get; set; }

        [Column(TypeName = "Datetime")]
        public DateTime? ModifiedOn { get; set; }

        public virtual ICollection<Deal> DealsAsClient
        {
            get { return this.dealsAsClient; }
            set { this.dealsAsClient = value; }
        }

        public virtual ICollection<Deal> DealsAsExecuter
        {
            get { return this.dealsAsExecuter; }
            set { this.dealsAsExecuter = value; }
        }

        public virtual ICollection<DealRequest> DealRequestsSent
        {
            get { return this.dealRequestsSent; }
            set { this.dealRequestsSent = value; }
        }

        public virtual ICollection<DealRequest> DealRequestsReceived
        {
            get { return this.dealRequestsReceived; }
            set { this.dealRequestsReceived = value; }
        }

        public virtual ICollection<Contact> ContactRequestsSent
        {
            get { return this.contactRequestsSent; }
            set { this.contactRequestsSent = value; }
        }

        public virtual ICollection<Contact> ContactRequestsReceived
        {
            get { return this.contactRequestsReceived; }
            set { this.contactRequestsReceived = value; }
        }

        public virtual ICollection<Objective> Objectives
        {
            get { return this.objectives; }
            set { this.objectives = value; }
        }

        public virtual ICollection<Team> Teams
        {
            get { return this.teams; }
            set { this.teams = value; }
        }

        public virtual ICollection<Message> MessagesSent
        {
            get { return this.messagesSent; }
            set { this.messagesSent = value; }
        }

        public virtual ICollection<Message> MessagesReceived
        {
            get { return this.messagesReceived; }
            set { this.messagesReceived = value; }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            ClaimsIdentity userIdentity = await manager
                .CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
    }
}
