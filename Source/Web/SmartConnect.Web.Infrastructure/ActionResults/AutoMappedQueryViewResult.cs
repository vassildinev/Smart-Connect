namespace SmartConnect.Web.Infrastructure.ActionResults
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;
    using Contracts;
    using Mappings;

    public class AutoMappedQueryViewResult<TSource, TResult> : ActionResult, IViewResult
    {
        public AutoMappedQueryViewResult(ViewResult view)
        {
            this.View = view;
        }

        public ViewResult View { get; private set; }

        public override void ExecuteResult(ControllerContext context)
        {
            var queryable = View.ViewData.Model as IQueryable<TSource>;
            View.ViewData.Model = queryable
                .ProjectTo<TResult>(StandardMapperObjectsProvider.MapperConfiguration);
            View.ExecuteResult(context);
        }
    }
}
