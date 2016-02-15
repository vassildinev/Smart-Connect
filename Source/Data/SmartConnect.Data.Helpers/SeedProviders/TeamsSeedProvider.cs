namespace SmartConnect.Data.Helpers.SeedProviders
{
    using System;
    using System.Collections.Generic;

    using Contracts;
    using Models;

    public class TeamsSeedProvider : ISeedProvider<Team>
    {
        private Random random = new Random();

        private IList<string> teams = new List<string>()
        {
            "Dolphin Pirates",
            "Retro Raiders",
            "Carnivore Rebels",
            "Carnivore Spiders",
            "Raging Legends",
            "Reptile Panthers",
            "Xtreme Racoons",
            "Blue Bulls",
            "Samurai Secret Agents",
            "Sneaky Robots",
            "Samurai Lightning",
            "Sneaky Soldiers",
            "Rhino Robots",
            "Tornado Widows",
            "Blue Piledrivers",
            "Knockout Panthers",
            "Ice Stingers",
            "Shockwave Kamikaze Pilots",
            "Tornado Wild",
            "Flying Cyborgs",
        };

        public IEnumerable<Team> GetSeedData()
        {
            return new List<Team>()
            {
                new Team()
                {
                    Name = this.teams[random.Next(0, this.teams.Count)]
                }
        };
    }
}
}
