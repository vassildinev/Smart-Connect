namespace SmartConnect.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Helpers.SeedProviders;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using Common.Constants;

    public sealed class DefaultMigrationConfiguration : DbMigrationsConfiguration<SmartConnectDbContext>
    {
        public DefaultMigrationConfiguration()
        {
            this.AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(SmartConnectDbContext context)
        {
            if(context.Users.Any())
            {
                return;
            }

            var random = new Random();

            // Seed Quotes
            var quotesProvider = new QuotesSeedProvider();
            var quotes = quotesProvider.GetSeedData();
            this.Seed(context, quotes);

            // Seed Countries
            var countriesProvider = new CountriesSeedProvider();
            var countries = countriesProvider.GetSeedData();
            this.Seed(context, countries);

            // Seed Roles
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);
            roleManager.Create(new IdentityRole() { Name = Roles.User });
            roleManager.Create(new IdentityRole() { Name = Roles.Moderator });
            roleManager.Create(new IdentityRole() { Name = Roles.Admin });

            // Seed Users, Teams, Deals, etc.
            var usersProvider = new UsersSeedProvider();
            var teamsProvider = new TeamsSeedProvider();
            var dealsProvider = new DealsSeedProvider();
            var requirementsProvider = new RequirementsSeedProvider();
            var dealRequestsProvider = new DealRequestsSeedProvider();
            var objectivesProvider = new ObjectivesSeedProvider();

            var userStore = new UserStore<User>(context);
            var userManager = new UserManager<User>(userStore);
            userManager.UserValidator = new UserValidator<User>(userManager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = false
            };

            userManager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false,
            };

            string userPassword = "123456";

            User admin = new User()
            {
                UserName = "vassildinev",
                Email = "vassildinev@gmail.com",
                FirstName = "Vasil",
                LastName = "Dinev",
                DateOfBirth = new DateTime(1994, 10, 22),
                Gender = Gender.Male
            };

            userManager.Create(admin, userPassword);
            userManager.AddToRole(admin.Id, Roles.Admin);
            userManager.AddToRole(admin.Id, Roles.Moderator);

            for (int i = 0; i < 5; i++)
            {
                // Seed the user, create a few deals, a few deal requests per deal and a few deal requirements per deal.
                // Then, create a new user per deal request.
                // Attach everything to the deal, then all deals to the user.

                User client = usersProvider.GetSeedData().FirstOrDefault();

                client.UserName = "user_" + Guid.NewGuid();
                client.Email = client.UserName + "@smartconnect.com";
                userManager.Create(client, userPassword);
                userManager.AddToRole(client.Id, Roles.User);

                var shouldHaveDeals = random.Next(0, 3) != 0;
                if (shouldHaveDeals)
                {
                    Team team = teamsProvider.GetSeedData().FirstOrDefault();
                    team.CreatedOn = DateTime.Now;

                    int teamSize = random.Next(2, 5);
                    IList<User> teamMembers = new List<User>();
                    for (int j = 0; j < teamSize; j++)
                    {
                        User teamMember = usersProvider.GetSeedData().FirstOrDefault();
                        teamMember.UserName = "user_" + Guid.NewGuid();
                        teamMember.Email = teamMember.UserName + "@smartconnect.com";
                        userManager.Create(teamMember, userPassword);
                        userManager.AddToRole(teamMember.Id, Roles.User);

                        teamMember.Teams.Add(team);
                        teamMembers.Add(teamMember);
                    }

                    IEnumerable<Deal> deals = dealsProvider.GetSeedData();
                    foreach (Deal deal in deals)
                    {
                        deal.Name = string.Concat(deal.Name, " ", i);

                        IEnumerable<Requirement> randomDealRequirements = requirementsProvider.GetSeedData();
                        IEnumerable<DealRequest> randomDealRequests = dealRequestsProvider.GetSeedData();
                        IEnumerable<Objective> randomObjectives = objectivesProvider.GetSeedData();

                        foreach (Requirement currentDealRequirement in randomDealRequirements)
                        {
                            deal.Requirements.Add(currentDealRequirement);
                        }

                        foreach (DealRequest currentDealRequest in randomDealRequests)
                        {
                            User sender = usersProvider.GetSeedData().FirstOrDefault();
                            sender.UserName = "user_" + Guid.NewGuid();
                            sender.Email = sender.UserName + "@smartconnect.com";

                            userManager.Create(sender, userPassword);
                            userManager.AddToRole(sender.Id, Roles.User);

                            currentDealRequest.Sender = sender;
                            currentDealRequest.Receiver = client;

                            if (currentDealRequest.IsConfirmed)
                            {
                                deal.Executer = sender;
                            }

                            deal.Requests.Add(currentDealRequest);
                        }

                        foreach (Objective currentObjective in randomObjectives)
                        {
                            User randomTeamMember = teamMembers[random.Next(0, teamSize)];
                            currentObjective.ResponsibleUser = randomTeamMember;

                            deal.Objectives.Add(currentObjective);
                        }

                        deal.Executer.Teams.Add(team);
                        deal.Client = client;
                        this.Seed(context, deal);
                    }
                }
            }
        }

        private void Seed<TEntity>(SmartConnectDbContext context, IEnumerable<TEntity> data)
            where TEntity : class
        {
            var set = context.Set<TEntity>();
            set.AddRange(data);
            context.SaveChanges();
        }

        private void Seed<TEntity>(SmartConnectDbContext context, TEntity data)
            where TEntity : class
        {
            var set = context.Set<TEntity>();
            set.Add(data);
            context.SaveChanges();
        }
    }
}
