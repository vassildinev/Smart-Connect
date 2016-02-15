namespace SmartConnect.Data.Models
{
    using System.Collections.Generic;

    using Contracts;

    public class Team : BaseModel<int>
    {
        private ICollection<User> members;

        public Team()
        {
            this.members = new HashSet<User>();
        }

        public string Name { get; set; }

        public virtual ICollection<User> Members
        {
            get { return this.members; }
            set { this.members = value; }
        }
    }
}
