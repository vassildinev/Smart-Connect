﻿namespace SmartConnect.Web.Infrastructure.Registries
{
    using Contracts;
    using Data;
    using Data.Contracts;
    using Data.Repositories;
    using Data.Repositories.Contracts;
    using Ninject;
    using Ninject.Web.Common;

    public class DataBindingsRegistry : INinjectRegistry
    {
        public void Register(IKernel kernel)
        {
            //kernel.Bind<ISmartConnectDbContext>().To<SmartConnectDbContext>().InRequestScope();
            kernel.Bind(typeof(IRepository<,>)).To(typeof(GenericRepository<,>));
        }
    }
}
