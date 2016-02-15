namespace SmartConnect.Data.Helpers.SeedProviders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Models;

    public class RequirementsSeedProvider : ISeedProvider<Requirement>
    {
        private Random random = new Random();

        private IEnumerable<string> requirements;

        public RequirementsSeedProvider()
        {
            this.requirements = new List<string>()
            {
                    "Those store clerks take a photograph.",
                    "Those students played tennis.",
                    "They tie a knot.",
                    "Those janitors fed the baby.",
                    "I shot a gun.",
                    "Jennifer painted the door.",
                    "I drive a sports car.",
                    "Those gardeners fly a kite.",
                    "They drove a car.",
                    "Those news announcers kick a ball.",
                    "I lifted weights.",
                    "Ginger takes a test.",
                    "They fried an egg.",
                    "I drive a sports car.",
                    "Jennifer washed clothes.",
                    "That carpenter lifted weights.",
                    "That doctor ties a knot.",
                    "Those bankers serve dinner."
            };
        }

        public IEnumerable<Requirement> GetSeedData()
        {
            int randomTake = random.Next(2, 7) + 1;
            return this.requirements
                .OrderBy(r => Guid.NewGuid())
                .Take(randomTake)
                .Select(x => new Requirement()
                {
                    Name = x,
                    IsFulfilled = random.Next(0, 2) == 0,
                    Priority = (RequirementPriority)random.Next(0, 3)
                });
        }
    }
}
