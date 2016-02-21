namespace SmartConnect.Web.ViewModels.Admin.Quotes
{
    using System.ComponentModel.DataAnnotations;

    using Admin;
    using Data.Models;
    using Infrastructure.Mappings;

    public class AdminQuoteViewModel : BaseAdministrationViewModel<Quote, int>, IMapFrom<Quote>
    {
        [Required]
        [MaxLength(60)]
        public string Author { get; set; }

        [Required]
        [MaxLength(500)]
        public string Content { get; set; }

        public bool IsDeleted { get; set; }
    }
}
