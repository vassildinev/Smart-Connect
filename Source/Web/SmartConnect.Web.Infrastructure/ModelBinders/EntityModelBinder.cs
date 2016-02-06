namespace SmartConnect.Web.Infrastructure.ModelBinders
{
    using System.Web.Mvc;

    using Data.Models.Contracts;
    using Data.Repositories.Contracts;

    public class EntityModelBinder<TEntity> : IModelBinder
        where TEntity : class, IEntity
    {
        private readonly IRepository<TEntity> repository;

        public EntityModelBinder(IRepository<TEntity> repository)
        {
            this.repository = repository;
        }

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var value = bindingContext.ValueProvider.GetValue("id");
            var id = int.Parse(value.AttemptedValue as string);
            var entity = this.repository.GetById(id);
            return entity;
        }
    }
}
