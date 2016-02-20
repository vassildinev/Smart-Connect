namespace SmartConnect.Web.Controllers.Contracts
{
    using System.Web.Mvc;

    using Data.Models.Contracts;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Services.Common.Contracts;

    public abstract class KendoGridAdministrationController<TModel, TViewModel, TKey> : 
        BaseAdministrationController, 
        IKendoGridAdministrationController<TModel, TViewModel, TKey>
        where TModel : class, IEntity<TKey>
        where TViewModel : class
    {
        public KendoGridAdministrationController(IDataService<TModel, TKey> dataService)
        {
            this.DataService = dataService;
        }

        public IDataService<TModel, TKey> DataService { get; protected set; }

        [HttpPost]
        public abstract ActionResult Create([DataSourceRequest]DataSourceRequest request, TViewModel model);

        [HttpPost]
        public ActionResult Read([DataSourceRequest]DataSourceRequest request)
        {
            var data = this.DataService.All().ToDataSourceResult(request);
            return this.Json(data);
        }

        [HttpPost]
        public abstract ActionResult Update([DataSourceRequest] DataSourceRequest request, TViewModel viewModel);

        [HttpPost]
        public abstract ActionResult Destroy([DataSourceRequest]DataSourceRequest request, TViewModel model);

        [NonAction]
        protected virtual TModel CreateRecord(TViewModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                TModel dbModel = Mapper.Map<TModel>(model);
                this.DataService.Create(dbModel);
                return dbModel;
            }

            return null;
        }


        [NonAction]
        protected virtual void UpdateModel(TViewModel model, TKey id)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var dbModel = this.DataService.GetById(id);
                this.Mapper.Map(model, dbModel);
                this.DataService.Update(dbModel);
                this.DataService.SaveChanges();
            }
        }

        [NonAction]
        protected JsonResult GridResult(TViewModel model, [DataSourceRequest]DataSourceRequest request)
        {
            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }
    }
}
