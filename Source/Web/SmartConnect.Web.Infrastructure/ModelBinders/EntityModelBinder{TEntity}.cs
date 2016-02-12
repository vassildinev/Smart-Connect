namespace SmartConnect.Web.Infrastructure.ModelBinders
{
    using System;
    using System.Web.Mvc;

    using Contracts;
    using Data.Models.Contracts;
    using Data.Repositories.Contracts;

    public class EntityModelBinder<TEntity> : IModelBinder<TEntity, Guid>
        where TEntity : class, IEntity<Guid>
    {
        private readonly IRepository<TEntity, Guid> repository;

        public EntityModelBinder(IRepository<TEntity, Guid> repository)
        {
            this.repository = repository;
        }

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var value = bindingContext.ValueProvider.GetValue("id");
            var id = Guid.Parse(value.AttemptedValue);
            var entity = this.repository.GetById(id);
            return entity;
        }
    }
}
