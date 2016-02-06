namespace SmartConnect.Web.Controllers.Contracts
{
    using System.Web.Mvc;

    using Infrastructure.ActionResults;
    using System.Web;
    using System.Web.Routing;
    using System;

    public class BaseController : Controller
    {
        protected override IAsyncResult BeginExecute(RequestContext requestContext, AsyncCallback callback, object state)
        {
            return base.BeginExecute(requestContext, callback, state);
        }

        protected AutoMappedObjectResult<TSource, TResult> AutoMappedObjectView<TSource, TResult>(ViewResult view)
            where TSource : class
        {
            return new AutoMappedObjectResult<TSource, TResult>(view);
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            if (filterContext.ExceptionHandled)
            {
                return;
            }

            if (this.Request.IsAjaxRequest())
            {
                var exception = filterContext.Exception as HttpException;

                if (exception != null)
                {
                    this.Response.StatusCode = exception.GetHttpCode();
                    this.Response.StatusDescription = exception.Message;
                }
            }
            else
            {
                var controllerName = ControllerContext.RouteData.Values["controller"].ToString();
                var actionName = ControllerContext.RouteData.Values["action"].ToString();
                this.View("Errors", new HandleErrorInfo(filterContext.Exception, controllerName, actionName)).ExecuteResult(this.ControllerContext);
            }

            filterContext.ExceptionHandled = true;
        }

        protected AutoMappedQueryViewResult<TSource, TResult> AutoMappedQueryView<TSource, TResult>(ViewResult view)
        {
            return new AutoMappedQueryViewResult<TSource, TResult>(view);
        }

        protected ActionHandlerResult<TData> ActionHandlerFor<TData>(ActionResult success, TData data = null)
            where TData : class
        {
            return this.ActionHandlerFor(success, null, data);
        }

        protected ActionHandlerResult<TData> ActionHandlerFor<TData>(ActionResult success, ActionResult failure = null, TData data = null)
            where TData : class
        {
            return new ActionHandlerResult<TData>(data, success, failure);
        }

        protected ActionHandlerWithModelResult<TData> ActionHandlerWithModelFor<TData>(ActionResult success, ActionResult failure = null)
            where TData : class
        {
            return new ActionHandlerWithModelResult<TData>(success, failure);
        }

        protected PostedDataResultActionHandlerResult<TData> PostedDataActionHandlerFor<TData>(TData data, ActionResult success, ActionResult failure)
            where TData : class
        {
            return new PostedDataResultActionHandlerResult<TData>(data, success, failure);
        }
    }
}
