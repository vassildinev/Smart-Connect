namespace SmartConnect.Web.Controllers.Contracts
{
    using System.Web.Mvc;

    using Common.Constants;
    using Data.Models;
    using Data.Models.Contracts;
    using Services.Common.Contracts;
    using ViewModels.Common;

    [Authorize(Roles = Roles.Admin)]
    public abstract class KendoGridAdministrationController<TModel, TViewModel, TKey> :
        KendoGridController<TModel, TViewModel, TKey>,
        IKendoGridController<TModel, TViewModel, TKey>
        where TModel : class, IEntity<TKey>
        where TViewModel : BaseViewModel<TModel, TKey>
    {        
        public KendoGridAdministrationController(IDataService<User, string> users, IDataService<TModel, TKey> data)
            : base(users, data)
        {
            this.Data = data;
        }
    }
}
