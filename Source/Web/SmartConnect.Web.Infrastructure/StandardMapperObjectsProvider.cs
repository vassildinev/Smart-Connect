namespace SmartConnect.Web.Infrastructure
{
    using AutoMapper;
    using Mappings;

    public class StandardMapperObjectsProvider : IMapperObjectsProvider
    {
        private static volatile IMapperObjectsProvider mapperObjectsProvider;

        private static object syncLock = new object();
        
        private StandardMapperObjectsProvider()
        {
            this.MapperConfiguration = new MapperConfiguration(config => { });
            this.Mapper = (this.MapperConfiguration as MapperConfiguration).CreateMapper();
        }

        public static IMapperObjectsProvider Instance
        {
            get
            {
                if (mapperObjectsProvider == null)
                {
                    lock (syncLock)
                    {
                        if (mapperObjectsProvider == null)
                        {
                            mapperObjectsProvider = new StandardMapperObjectsProvider();
                        }
                    }
                }

                return mapperObjectsProvider;
            }
        }

        public IMapper Mapper { get; private set; }

        public IMapperConfiguration MapperConfiguration { get; private set; }
    }
}
