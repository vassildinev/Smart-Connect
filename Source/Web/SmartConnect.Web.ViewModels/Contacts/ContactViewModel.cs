namespace SmartConnect.Web.ViewModels.Contacts
{
    using AutoMapper;
    using Common;
    using Data.Models;
    using Infrastructure.Mappings;

    public class ContactViewModel : BaseViewModel<Contact, int>, IMapFrom<Contact>, IHaveCustomMappings
    {
        public string Sender { get; set; }

        public string Receiver { get; set; }

        public void CreateMappings(IMapperConfiguration mapperConfiguration)
        {
            mapperConfiguration
                .CreateMap<Contact, ContactViewModel>()
                .ForMember(m => m.Sender, opt => opt.MapFrom(c => c.Sender.UserName));

            mapperConfiguration
                .CreateMap<Contact, ContactViewModel>()
                .ForMember(m => m.Receiver, opt => opt.MapFrom(c => c.Receiver.UserName));
        }
    }
}
