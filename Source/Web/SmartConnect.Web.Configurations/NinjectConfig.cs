[assembly: WebActivatorEx.PreApplicationStartMethod(
    typeof(SmartConnect.Web.Configurations.NinjectConfig), 
    SmartConnect.Web.Common.Constants.Ninject.PreApplicationStartMethodName)]
[assembly: WebActivatorEx.ApplicationShutdownMethod(
    typeof(SmartConnect.Web.Configurations.NinjectConfig),
    SmartConnect.Web.Common.Constants.Ninject.PreApplicationShutdownMethodName)]

namespace SmartConnect.Web.Configurations
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Common;

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
        }        
    }
}
