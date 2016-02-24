namespace SmartConnect.Web.ViewModels.Deals
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Common;
    using Data.Models;
    using Infrastructure.Mappings;

    public class DealViewModel : BaseViewModel<Deal, int>, IMapFrom<Deal>
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [Range(0.0, double.MaxValue)]
        public decimal Value { get; set; }

        public string ClientId { get; set; }

        public IEnumerable<RequirementViewModel> Requirements { get; set; }
    }
}
