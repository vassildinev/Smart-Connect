namespace SmartConnect.Web.Infrastructure.ActionResults
{
    using System.Web.Mvc;

    using Base;
    using Contracts;
    using Infrastructure;

    public class ActionHandlerResult<T> : BaseActionHandlerWithDataResult<T>
        where T : class 
    {
        public ActionHandlerResult(T data, ActionResult success, ActionResult failure = null)
            : base(data, success, failure)
        {
        }

        public override void ExecuteResult(ControllerContext context)
        {
            base.ExecuteResult(context, () =>
            {
                var handler = ObjectFactory.Instance.GetInstance<IActionHandler<T>>();
                handler.Handle(this.Data);
            });
        }
    }
}
