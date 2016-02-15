namespace SmartConnect.Data.Helpers.SeedProviders
{
    using System.Collections.Generic;
    using Contracts;
    using Models;

    public class ObjectivesSeedProvider : ISeedProvider<Objective>
    {
        public IEnumerable<Objective> GetSeedData()
        {
            return new List<Objective>()
            {
                new Objective() {  }
            };
        }
    }
}
