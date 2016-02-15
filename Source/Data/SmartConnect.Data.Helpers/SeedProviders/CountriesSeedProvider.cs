namespace SmartConnect.Data.Helpers.SeedProviders
{
    using System.Collections.Generic;

    using Contracts;
    using Models;

    public class CountriesSeedProvider : ISeedProvider<Country>
    {
        public IEnumerable<Country> GetSeedData()
        {
            return new List<Country>()
            {
                new Country() { Name = "Albania" },
                new Country() { Name = "Andorra" },
                new Country() { Name = "Austria" },
                new Country() { Name = "Belarus" },
                new Country() { Name = "Belgium" },
                new Country() { Name = "Bosnia and Herzegovina" },
                new Country() { Name = "Bulgaria" },
                new Country() { Name = "Croatia" },
                new Country() { Name = "Cyprus" },
                new Country() { Name = "Czech Republic" },
                new Country() { Name = "Denmark" },
                new Country() { Name = "Estonia" },
                new Country() { Name = "Finland" },
                new Country() { Name = "France" },
                new Country() { Name = "Germany" },
                new Country() { Name = "Greece" },
                new Country() { Name = "Hungary" },
                new Country() { Name = "Iceland" },
                new Country() { Name = "Italy" },
                new Country() { Name = "Kosovo" },
                new Country() { Name = "Latvia" },
                new Country() { Name = "Liechtenstein" },
                new Country() { Name = "Luthuania" },
                new Country() { Name = "Luxemburg" },
                new Country() { Name = "Macedonia" },
                new Country() { Name = "Malta" },
                new Country() { Name = "Moldova" },
                new Country() { Name = "Monaco" },
                new Country() { Name = "Montenegro" },
                new Country() { Name = "Norway" },
                new Country() { Name = "Poland" },
                new Country() { Name = "Portugal" },
                new Country() { Name = "Romania" },
                new Country() { Name = "Russia" },
                new Country() { Name = "San Marino" },
                new Country() { Name = "Serbia" },
                new Country() { Name = "Slovakia" },
                new Country() { Name = "Slovenia" },
                new Country() { Name = "Spain" },
                new Country() { Name = "Sweden" },
                new Country() { Name = "Switzerland" },
                new Country() { Name = "The Netherlands" },
                new Country() { Name = "The United Kingdom" },
                new Country() { Name = "Turkey" },
                new Country() { Name = "Ukraine" },
                new Country() { Name = "Vatican City State" }
            };
        }
    }
}
