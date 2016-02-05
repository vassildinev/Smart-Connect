﻿namespace SmartConnect.Web.Infrastructure.Mappings
{
    using AutoMapper;

    public interface IHaveCustomMappings
    {
        void CreateMappings(IMapperConfiguration mapperConfiguration);
    }
}
