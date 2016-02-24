namespace SmartConnect.Web.Controllers.Deals
{
    using System;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;
    using Contracts;
    using Data.Models;
    using Infrastructure.CustomAttributes;
    using Infrastructure.Mappings;
    using Kendo.Mvc.UI;
    using Microsoft.AspNet.Identity;
    using Services.Users.Contracts;
    using Services.Deals.Contracts;
    using ViewModels.Deals;
    using System.Linq;

    public class DealsAjaxController :
        KendoGridController<Deal, DealViewModel, int>,
        IKendoGridController<Deal, DealViewModel, int>
    {
        public DealsAjaxController(IUsersService users, IDealsService data)
            : base(users, data)
        {
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ReadCurrentDeals([DataSourceRequest]DataSourceRequest request)
        {
            string userId = this.User.Identity.GetUserId();
            var data = (this.Data as IDealsService)
                .ByUserIdCurrent(userId)
                .ProjectTo<DealViewModel>(StandardMapperObjectsProvider.MapperConfiguration);
            return this.CollectionGridResult(request, data);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ReadDealsWon([DataSourceRequest]DataSourceRequest request)
        {
            string userId = this.User.Identity.GetUserId();
            var data = (this.Data as IDealsService)
                .ByUserIdWon(userId)
                .ProjectTo<DealViewModel>(StandardMapperObjectsProvider.MapperConfiguration);
            return this.CollectionGridResult(request, data);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ReadDealsLost([DataSourceRequest]DataSourceRequest request)
        {
            string userId = this.User.Identity.GetUserId();
            var data = (this.Data as IDealsService)
                .ByUserIdLost(userId)
                .ProjectTo<DealViewModel>(StandardMapperObjectsProvider.MapperConfiguration);
            return this.CollectionGridResult(request, data);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ReadOwnDeals([DataSourceRequest]DataSourceRequest request)
        {
            string userId = this.User.Identity.GetUserId();
            var data = (this.Data as IDealsService)
                .ByUserIdOwn(userId)
                .ProjectTo<DealViewModel>(StandardMapperObjectsProvider.MapperConfiguration).ToList();
            return this.CollectionGridResult(request, data);
        }

        [AjaxOnly]
        public ActionResult GetById(int id)
        {
            if(id == 0)
            {
                throw new ArgumentException("Id must be a positive integer");
            }

            string userId = this.User.Identity.GetUserId();
            Deal deal = this.Data.GetById(id);

            // TODO: Check if user is not part of the team, led by the deal executer
            if (deal.ExecuterId != userId && deal.ClientId != userId)
            {
                throw new InvalidOperationException("Access denied, this is not your deal");
            }

            DealViewModel model = this.Mapper.Map<DealViewModel>(deal);
            return this.PartialView("~/Views/Deals/Home/_DealDetailsPartial.cshtml", model);
        }
    }
}
