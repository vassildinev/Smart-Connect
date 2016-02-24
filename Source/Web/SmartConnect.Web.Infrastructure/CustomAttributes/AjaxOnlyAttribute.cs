namespace SmartConnect.Web.Infrastructure.CustomAttributes
{
    using System;
    using System.Web.Mvc;

    public class AjaxOnlyAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!filterContext.HttpContext.Request.IsAjaxRequest())
            {
                throw new InvalidOperationException("~/Deals/Home/GetById can be called using AJAX only");
            }
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
        }
    }
}
