namespace SmartConnect.Web.Infrastructure.Mappings
{
    using AutoMapper;

    public interface IMapperObjectsProvider
    {
        IMapperConfiguration MapperConfiguration { get; }

        IMapper Mapper { get; }
    }
}
