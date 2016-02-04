namespace SmartConnect.Web.Infrastructure.Registries
{
    using System;
    using System.Linq;

    using Common.Constants;
    using Contracts;
    using Ninject;
    using Ninject.Extensions.Conventions;
    using Ninject.Web.Common;

    public class ServicesRegistry : INinjectRegistry
    {
        public void Register(IKernel kernel)
        {
            AppDomain
                .CurrentDomain
                .GetAssemblies()
                .Select(assembly => assembly.GetName().Name)
                .Where(assemblyName => assemblyName != Assemblies.CommonServices && 
                                       assemblyName != Assemblies.IdentityServices)
                .ToList()
                .ForEach(assemblyName => 
                {
                    kernel
                    .Bind(b => b.From(assemblyName)
                    .SelectAllClasses()
                    .BindDefaultInterface()
                    .Configure(x => x.InRequestScope()));
                });
        }
    }
}
