namespace SmartConnect.Web.Controllers.Deals
{
    using Contracts;
    using Data.Models;
    using Services.Users.Contracts;
    using Services.Deals.Contracts;
    using ViewModels.Deals;

    public class DealsAjaxController :
        KendoGridAdministrationController<Deal, DealViewModel, int>,
        IKendoGridAdministrationController<Deal, DealViewModel, int>
    {
        public DealsAjaxController(IUsersService users, IDealsService data)
            : base(users, data)
        {
        }
    }
}
