namespace SmartConnect.Web.ViewModels
{
    using Data.Models;
    using Infrastructure.Mappings;

    public class QuoteViewModel : IMapFrom<Quote>
    {
        public string Author { get; set; }

        public string Content { get; set; }
    }
}
