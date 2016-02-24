namespace SmartConnect.Data.Models
{
    using System.Collections.Generic;

    using Contracts;

    public class Country : BaseModel<int>
    {
        private ICollection<User> users;

        public Country()
            : base()
        {
            this.users = new HashSet<User>();
        }

        public string Name { get; set; }

        public virtual ICollection<User> Users
        {
            get { return this.users; }
            set { this.users = value; }
        }
    }
}