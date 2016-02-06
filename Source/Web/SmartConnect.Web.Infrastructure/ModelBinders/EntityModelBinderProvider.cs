namespace SmartConnect.Web.Infrastructure.ModelBinders
{
    using Data.Models.Contracts;
    using System;
    using System.Web.Mvc;

    public class EntityModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(Type modelType)
        {
            if (!typeof(IEntity).IsAssignableFrom(modelType))
            {
                return null;
            }

            var modelBinderType = typeof(EntityModelBinder<>).MakeGenericType(modelType);
            var modelBinder = ObjectFactory.Instance.GetInstance(modelBinderType);

            return (IModelBinder)modelBinder;
        }
    }
}
