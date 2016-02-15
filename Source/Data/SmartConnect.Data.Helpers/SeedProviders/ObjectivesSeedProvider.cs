namespace SmartConnect.Data.Helpers.SeedProviders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Models;

    public class ObjectivesSeedProvider : ISeedProvider<Objective>
    {
        private Random random  = new Random();

        private IList<string> objectives = new List<string>()
        {
            "A stretched blast excuses the disclaimer.",
            "Why won't a traced emulator stagger a parameter?",
            "The tricky sneak forks a dreaded crystal.",
            "Inside the quiz retracts the fundamentalist.",
            "A knowing abuse pretends my blanket within an assistant name.",
            "A famous bear cheats beside the immoral scene.",
            "The massive mouth speaks the dedicated dependence.",
            "The creature apologizes above the happy prize.",
            "The dust takes the distracted fish next to the triumph.",
            "Behind her silver rattles a seen vocabulary.",
            "The bass shelves the misfortune.",
            "The mist towers over the ladder into this business applause.",
            "An attribute offends throughout a warmed search.",
            "The splitting alcoholic disappears outside the lying powder.",
            "An alien reactor disturbs the mount.",
            "The decade thirsts inside a jolly dispute.",
            "An entitled photograph uses a satisfactory manager.",
            "A sliced relief compliments the hangover.",
            "A knowing hash propositions her disturbance.",
            "A mechanism parrots the archive.",
            "The flesh sizes the wrecked clash.",
            "The detail secures a strange husband against an alternative.",
            "The distant abuse breathes over the gesture.",
            "Any late lady colors below its unnecessary wit.",
            "A brush distributes the accomplished fish.",
            "The drum farces the nearer cramp.",
            "A space oils the attribute with the convenient absolute.",
            "The decided percentage pretends throughout a southern machinery.",
        };

        public IEnumerable<Objective> GetSeedData()
        {
            int randomNumberOfObjectives = random.Next(0, 5);
            int days = random.Next(0, 200) - 100;

            return this.objectives
                .OrderBy(o => Guid.NewGuid())
                .Take(randomNumberOfObjectives)
                .Select(x => new Objective()
                {
                    Name = x,
                    Deadline = DateTime.Now.AddDays(days),
                    Status = (ObjectiveStatus)(days < 0 ? random.Next(0, 2) : 3)
                });
        }
    }
}
