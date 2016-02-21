namespace SmartConnect.Web.ViewModels.Common
{
    using Data.Models.Contracts;
    using Infrastructure.Mappings;


    public abstract class BaseViewModel<TModel, TKey> : IMapFrom<TModel>
        where TModel: class, IEntity<TKey>
    {
        public TKey Id { get; set; }
    }
}
