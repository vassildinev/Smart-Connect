namespace SmartConnect.Web.Infrastructure.ActionResults.Base
{
    using System.Web.Mvc;

    public abstract class BaseActionHandlerWithDataResult<T> : BaseActionHandlerResult<T>
        where T : class
    {
        protected BaseActionHandlerWithDataResult(T data, ActionResult success, ActionResult failure = null)
            : base(success, failure)
        {
            this.Data = data;
        }

        public T Data { get; private set; }
    }
}
