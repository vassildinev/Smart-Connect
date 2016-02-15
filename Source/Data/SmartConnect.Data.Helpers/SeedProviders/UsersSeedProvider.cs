namespace SmartConnect.Data.Helpers.SeedProviders
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using Contracts;
    using Models;

    public class UsersSeedProvider : ISeedProvider<User>
    {
        private IList<string> firstNames = new List<string>()
        {
            "John", "Bob", "Robert", "Ivan", "Vasil", "Petranka", "Dragan", "Peter", "George", "Stamat", "Nick"
        };

        private IList<string> lastNames = new List<string>()
        {
            "Smith", "Petroff", "Black", "Vasileff", "Pavloff", "Bush", "Johnson", "Washington", "Roberts", "Middleton", "Murray"
        };

        private Random random = new Random();

        public IEnumerable<User> GetSeedData()
        {
            int firstNamesLength = this.firstNames.Count();
            int lastNamesLength = this.lastNames.Count();

            return new List<User>()
            {
                new User()
                {
                    FirstName = this.firstNames[random.Next(0, firstNamesLength)],
                    LastName = this.lastNames[random.Next(0, lastNamesLength)],
                    DateOfBirth = DateTime.UtcNow.AddDays(-random.Next(18 * 365, 42 * 365)),
                    Gender = (Gender)random.Next(0, 2)
                }
            };
        }
    }
}
