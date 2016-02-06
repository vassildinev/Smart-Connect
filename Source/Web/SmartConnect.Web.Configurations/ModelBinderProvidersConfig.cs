namespace SmartConnect.Web.Configurations
{
    using System.Web.Mvc;

    using Infrastructure.ModelBinders;

    public static class ModelBinderProvidersConfig
    {
        public static void RegisterModelBinderProviders()
        {
            ModelBinderProviders.BinderProviders.Add(new EntityModelBinderProvider());
        }
    }
}
