namespace SmartConnect.Web.Infrastructure.ActionResults.Base
{
    using System;
    using System.Web.Mvc;

    using Contracts;

    public abstract class BaseActionHandlerResult<T> : ActionResult, IActionHandlerResult
        where T : class 
    {
        protected BaseActionHandlerResult(ActionResult success, ActionResult failure = null)
        {
            this.Success = success;
            this.Failure = failure;
        }

        public ActionResult Success { get; private set; }

        public ActionResult Failure { get; private set; }

        protected void ExecuteResult(ControllerContext context, Action action)
        {
            if (this.Failure != null && !context.Controller.ViewData.ModelState.IsValid)
            {
                this.Failure.ExecuteResult(context);
                return;
            }

            try
            {
                action();
            }
            catch (Exception ex)
            {
                if (this.Failure != null)
                {
                    this.Failure.ExecuteResult(context);
                    return;
                }

                throw ex;
            }

            this.Success.ExecuteResult(context);
        }
    }
}
