namespace SmartConnect.Web.Infrastructure.Mappings
{
    using AutoMapper;

    public static class StandardMapperObjectsProvider
    {    
        public static MapperConfiguration MapperConfiguration { get; private set; }

        public static void Initialize(MapperConfiguration configuration)
        {
            MapperConfiguration = configuration;
        }
    }
}
