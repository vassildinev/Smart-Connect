namespace SmartConnect.Web.ViewModels.Deals
{
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;
    using Common;
    using Data.Models;
    using Infrastructure.Mappings;

    public class RequirementViewModel : BaseViewModel<Requirement, int>, IMapFrom<Requirement>, IHaveCustomMappings
    {

        [Required]
        [MaxLength(150)]
        public string Name { get; set; }

        public bool IsFulfilled { get; set; }

        [Required]
        public string Priority { get; set; }

        [Required]
        public int DealId { get; set; }

        public void CreateMappings(IMapperConfiguration mapperConfiguration)
        {
            mapperConfiguration
                .CreateMap<Requirement, RequirementViewModel>()
                .ForMember(x => x.Priority, opt => opt.MapFrom(y => y.Priority.ToString()));
        }
    }
}
