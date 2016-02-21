namespace SmartConnect.Web.ViewModels.Deals
{
    using Common;
    using Data.Models;
    using Infrastructure.Mappings;

    public class DealViewModel : BaseViewModel<Deal, int>, IMapFrom<Deal>
    {
        public string Name { get; set; }

        public decimal Value { get; set; }
    }
}
