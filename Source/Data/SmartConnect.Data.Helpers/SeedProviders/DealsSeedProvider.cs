namespace SmartConnect.Data.Helpers.SeedProviders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Models;

    public class DealsSeedProvider : ISeedProvider<Deal>
    {
        private Random random = new Random();

        public IEnumerable<Deal> GetSeedData()
        {
            return new List<Deal>()
            {
                new Deal()
                {
                    Name = "Furious Cobra",
                    Value = (decimal)random.NextDouble() * 199500 + 500
                },
                new Deal()
                {
                    Name = "Helpless Metaphor",
                    Value = (decimal)random.NextDouble() * 199500 + 500
                },
                new Deal()
                {
                    Name = "Discarded Dinosaur",
                    Value = (decimal)random.NextDouble() * 199500 + 500
                },
                new Deal()
                {
                    Name = "Eager Blue Tuba",
                    Value = (decimal)random.NextDouble() * 199500 + 500
                },
                new Deal()
                {
                    Name = "Rebel Neutron",
                    Value = (decimal)random.NextDouble() * 199500 + 500
                },
                new Deal()
                {
                    Name = "Brown Plastic",
                    Value = (decimal)random.NextDouble() * 199500 + 500
                },
                new Deal()
                {
                    Name = "Dusty Door",
                    Value = (decimal)random.NextDouble() * 199500 + 500
                },
                new Deal()
                {
                    Name = "Brown Roadrunner",
                    Value = (decimal)random.NextDouble() * 199500 + 500
                },
                new Deal()
                {
                    Name = "Ghastly Serpent",
                    Value = (decimal)random.NextDouble() * 199500 + 500
                },
                new Deal()
                {
                    Name = "Dreaded Tainted Ray",
                    Value = (decimal)random.NextDouble() * 199500 + 500
                },
                new Deal()
                {
                    Name = "Raw Scoreboard",
                    Value = (decimal)random.NextDouble() * 199500 + 500
                },
                new Deal()
                {
                    Name = "Reborn Gravel",
                    Value = (decimal)random.NextDouble() * 199500 + 500
                },
                new Deal()
                {
                    Name = "Pluto Disappointed",
                    Value = (decimal)random.NextDouble() * 199500 + 500
                },
                new Deal()
                {
                    Name = "Swift Fish",
                    Value = (decimal)random.NextDouble() * 199500 + 500
                },
                new Deal()
                {
                    Name = "Lone Hammer",
                    Value = (decimal)random.NextDouble() * 199500 + 500
                },
                new Deal()
                {
                    Name = "Golden Locomotive",
                    Value = (decimal)random.NextDouble() * 199500 + 500
                },
                new Deal()
                {
                    Name = "Hot Trendy",
                    Value = (decimal)random.NextDouble() * 199500 + 500
                },
                new Deal()
                {
                    Name = "Yellow Donut",
                    Value = (decimal)random.NextDouble() * 199500 + 500
                },
                new Deal()
                {
                    Name = "Itchy Emerald",
                    Value = (decimal)random.NextDouble() * 199500 + 500
                },
                new Deal()
                {
                    Name = "Scattered Finger",
                    Value = (decimal)random.NextDouble() * 199500 + 500
                },
                new Deal()
                {
                    Name = "Dirty Waterbird",
                    Value = (decimal)random.NextDouble() * 199500 + 500
                },
                new Deal()
                {
                    Name = "Lonesome Scoreboard",
                    Value = (decimal)random.NextDouble() * 199500 + 500
                },
                new Deal()
                {
                    Name = "Magenta Xylophone",
                    Value = (decimal)random.NextDouble() * 199500 + 500
                },
                new Deal()
                {
                    Name = "Green Toothbrush",
                    Value = (decimal)random.NextDouble() * 199500 + 500
                },
                new Deal()
                {
                    Name = "Hidden Logbook",
                    Value = (decimal)random.NextDouble() * 199500 + 500
                },
                new Deal()
                {
                    Name = "Running Longitude",
                    Value = (decimal)random.NextDouble() * 199500 + 500
                },
                new Deal()
                {
                    Name = "Confidential Burst",
                    Value = (decimal)random.NextDouble() * 199500 + 500
                },
                new Deal()
                {
                    Name = "Boiling Wrench",
                    Value = (decimal)random.NextDouble() * 199500 + 500
                },
                new Deal()
                {
                    Name = "Solid Yard",
                    Value = (decimal)random.NextDouble() * 199500 + 500
                },
                new Deal()
                {
                    Name = "Shower Subtle",
                    Value = (decimal)random.NextDouble() * 199500 + 500
                },
            }
            .OrderBy(d => Guid.NewGuid())
            .Take(random.Next(1, 8));
        }
    }
}
