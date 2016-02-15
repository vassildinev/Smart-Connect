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

    public sealed class Configuration : DbMigrationsConfiguration<SmartConnectDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(SmartConnectDbContext context)
        {
            var random = new Random();

            var quotesProvider = new QuotesSeedProvider();
            var quotes = quotesProvider.GetSeedData();
            this.Seed(context, quotes);

            var countriesProvider = new CountriesSeedProvider();
            var countries = countriesProvider.GetSeedData();
            this.Seed(context, countries);

            var requirementsProvider = new RequirementsSeedProvider();
            var dealsProvider = new DealsSeedProvider();
            var dealRequestsSeedProvider = new DealRequestsSeedProvider();
            var usersProvider = new UsersSeedProvider();

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

            // Seed the user, create a few deals, a few deal requests per deal and a few deal requirements per deal.
            // Then, create a new user per deal request.
            // Attach everything to the deal, then all deals to the user.

            for (int i = 0; i < 5; i++)
            {
                User client = usersProvider.GetSeedData().FirstOrDefault();
                client.UserName = "user_" + Guid.NewGuid();
                client.Email = client.UserName + "@smartconnect.com";
                userManager.Create(client, userPassword);

                var shouldHaveDeals = random.Next(0, 3) != 0;
                if (shouldHaveDeals)
                {
                    IEnumerable<Deal> deals = dealsProvider.GetSeedData();
                    foreach (Deal deal in deals)
                    {
                        deal.Name = string.Concat(deal.Name, " ", i);

                        IEnumerable<Requirement> randomDealRequirements = requirementsProvider.GetSeedData();
                        IEnumerable<DealRequest> randomDealRequests = dealRequestsSeedProvider.GetSeedData();

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

                            currentDealRequest.Sender = sender;
                            currentDealRequest.Receiver = client;

                            if (currentDealRequest.IsConfirmed)
                            {
                                deal.Executer = sender;
                            }

                            deal.Requests.Add(currentDealRequest);
                        }

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
