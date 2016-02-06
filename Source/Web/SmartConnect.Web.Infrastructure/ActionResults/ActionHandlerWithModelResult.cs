namespace SmartConnect.Web.Infrastructure.ActionResults
{
    using System.Web.Mvc;
    using Base;
    using Contracts;
    using Infrastructure;

    public class ActionHandlerWithModelResult<T> : BaseActionHandlerResult<T>
        where T : class 
    {
        public ActionHandlerWithModelResult(ActionResult success, ActionResult failure = null)
            : base(success, failure)
        {
        }

        public override void ExecuteResult(ControllerContext context)
        {
            base.ExecuteResult(context, () =>
            {
                var handler = ObjectFactory.Instance.GetInstance<IActionHandlerWithModel<T>>();
                var model = handler.Handle();
                context.Controller.ViewData.Model = model;
            });
        }
    }
}
