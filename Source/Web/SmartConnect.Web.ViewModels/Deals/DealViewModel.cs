namespace SmartConnect.Web.ViewModels.Deals
{
    using Data.Models;
    using Infrastructure.Mappings;

    public class DealViewModel : IMapFrom<Deal>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Value { get; set; }
    }
}
