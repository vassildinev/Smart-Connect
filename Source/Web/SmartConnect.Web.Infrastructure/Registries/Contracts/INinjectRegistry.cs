namespace SmartConnect.Web.Infrastructure.Registries.Contracts
{
    using Ninject;

    public interface INinjectRegistry
    {
        void Register(IKernel kernel);
    }
}
