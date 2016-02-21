namespace SmartConnect.Web.ViewModels.Admin
{
    using Data.Models.Contracts;
    using Infrastructure.Mappings;


    public abstract class BaseAdministrationViewModel<TModel, TKey> : IMapFrom<TModel>
        where TModel: class, IEntity<TKey>
    {
        public TKey Id { get; set; }
    }
}
