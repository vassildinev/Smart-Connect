namespace SmartConnect.Web.Controllers.Contracts
{
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;
    using Data.Models;
    using Data.Models.Contracts;
    using Infrastructure.Mappings;
    using Kendo.Mvc.UI;
    using Services.Common.Contracts;
    using ViewModels.Common;

    public abstract class KendoGridController<TModel, TViewModel, TKey> :
        BaseAjaxController,
        IKendoGridController<TModel, TViewModel, TKey>
        where TModel : class, IEntity<TKey>
        where TViewModel : BaseViewModel<TModel, TKey>
    {        
        public KendoGridController(IDataService<User, string> users, IDataService<TModel, TKey> data)
            : base(users)
        {
            this.Data = data;
        }

        public IDataService<TModel, TKey> Data { get; protected set; }
        
        [AcceptVerbs(HttpVerbs.Post)]
        public virtual ActionResult Read([DataSourceRequest]DataSourceRequest request)
        {
            var data = this.Data
                .AllWithDeleted()
                .ProjectTo<TViewModel>(StandardMapperObjectsProvider.MapperConfiguration);
            return this.CollectionGridResult(request, data);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public virtual ActionResult Update([DataSourceRequest] DataSourceRequest request, TViewModel viewModel)
        {
            this.UpdateRecord(viewModel, viewModel.Id);
            return this.ObjectGridResult(request, viewModel);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public virtual ActionResult Destroy([DataSourceRequest]DataSourceRequest request, TViewModel viewModel)
        {
            if (viewModel != null)
            {
                // If entity is already deleted, revert deletion
                var databaseModel = this.Data.GetById(viewModel.Id);
                if(databaseModel.IsDeleted)
                {
                    databaseModel.IsDeleted = false;
                    databaseModel.DeletedOn = null;
                    viewModel = this.Mapper.Map<TModel, TViewModel>(databaseModel);
                    this.Data.Update(databaseModel);
                }
                else
                {
                    this.Data.Delete(databaseModel);
                }

                this.Data.SaveChanges();
            }

            return this.ObjectGridResult(request, viewModel);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public virtual ActionResult Create([DataSourceRequest]DataSourceRequest request, TViewModel viewModel)
        {
            TModel model = this.CreateRecord(viewModel);
            TViewModel result = this.GetCreatedModel(model);
            return this.ObjectGridResult(request, result);
        }
        
        [NonAction]
        protected TViewModel GetCreatedModel(TModel model)
        {
            TViewModel result = null;
            if (model != null)
            {
                result = this.Mapper.Map<TViewModel>(model);
            }

            return result;
        }

        [NonAction]
        protected TModel CreateRecord(TViewModel viewModel)
        {
            if (viewModel != null && this.ModelState.IsValid)
            {
                TModel dbModel = Mapper.Map<TModel>(viewModel);
                this.Data.Create(dbModel);
                this.Data.SaveChanges();
                return dbModel;
            }

            return null;
        }


        [NonAction]
        protected void UpdateRecord(TViewModel viewModel, TKey id)
        {
            if (viewModel != null && this.ModelState.IsValid)
            {
                var databaseModel = this.Data.GetById(id);
                this.Mapper.Map(viewModel, databaseModel);
                this.Data.Update(databaseModel);
                this.Data.SaveChanges();
            }
        }
    }
}
