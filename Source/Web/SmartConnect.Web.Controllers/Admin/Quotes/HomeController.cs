namespace SmartConnect.Web.Controllers.Admin.Quotes
{
    using System.Web.Mvc;

    using Contracts;
    using Data.Models;
    using Kendo.Mvc.UI;
    using Services.Quotes.Contracts;
    using ViewModels.Admin.Quotes;

    public class HomeController : 
        KendoGridAdministrationController<Quote, AdminQuoteViewModel, int>,
        IKendoGridAdministrationController<Quote, AdminQuoteViewModel, int>
    {
        public HomeController(IQuotesService quotes)
            : base(quotes)
        {
            this.indexHeading = "Quotes";
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public override ActionResult Update([DataSourceRequest] DataSourceRequest request, AdminQuoteViewModel viewModel)
        {
            // Check if model should be created
            if(viewModel.Id == 0)
            {
                Quote model = this.CreateRecord(viewModel);
                AdminQuoteViewModel result = this.GetCreatedModel(model);
                return this.ObjectGridResult(request, result);
            }

            return base.Update(request, viewModel);
        }
    }
}
