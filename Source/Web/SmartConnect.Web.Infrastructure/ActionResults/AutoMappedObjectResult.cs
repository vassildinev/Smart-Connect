namespace SmartConnect.Web.Infrastructure.ActionResults
{
    using AutoMapper;
    using System.Web.Mvc;

    public class AutoMappedObjectResult<TSource, TResult> : ActionResult
        where TSource : class
    {
        public AutoMappedObjectResult(ViewResult view, IMapper mapper)
        {
            this.View = view;
            this.Mapper = mapper;
        }

        public ViewResult View { get; private set; }

        protected IMapper Mapper { get; set; }

        public override void ExecuteResult(ControllerContext context)
        {
            var model = View.ViewData.Model as TSource;
            View.ViewData.Model = this.Mapper.Map<TResult>(model);
            View.ExecuteResult(context);
        }
    }
}
