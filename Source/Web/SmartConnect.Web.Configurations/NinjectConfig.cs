[assembly: WebActivatorEx.PreApplicationStartMethod(
    typeof(SmartConnect.Web.Configurations.NinjectConfig),
    nameof(SmartConnect.Web.Configurations.NinjectConfig.Start))]
[assembly: WebActivatorEx.ApplicationShutdownMethod(
    typeof(SmartConnect.Web.Configurations.NinjectConfig),
    nameof(SmartConnect.Web.Configurations.NinjectConfig.Stop))]

namespace SmartConnect.Web.Configurations
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Web;

    using Infrastructure.Registries.Contracts;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Common;
    using SmartConnect.Common.Constants;
    using Infrastructure;

    public static class NinjectConfig
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
                RegisterServices(kernel);

                var objectFactory = ObjectFactory.Instance;
                objectFactory.InitializeKernel(kernel);

                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        private static void RegisterServices(IKernel kernel)
        {
            Assembly.Load(Assemblies.WebInfrastructure)
                .GetExportedTypes()
                .Where(type => type.IsClass && typeof(INinjectRegistry).IsAssignableFrom(type))
                .ToList()
                .ForEach(registry =>
                {
                    var registryInstance = (INinjectRegistry)Activator.CreateInstance(registry);
                    registryInstance.Register(kernel);
                });
        }
    }
}
