namespace SmartConnect.Web.Infrastructure.ActionResults
{
    using AutoMapper;
    using System.Web.Mvc;

    public class AutoMappedObjectResult<TSource, TResult> : ActionResult
        where TSource : class
    {
        public ViewResult View { get; private set; }

        public AutoMappedObjectResult(ViewResult view)
        {
            this.View = view;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            var model = View.ViewData.Model as TSource;
            View.ViewData.Model = Mapper.Map<TResult>(model);
            View.ExecuteResult(context);
        }
    }
}
