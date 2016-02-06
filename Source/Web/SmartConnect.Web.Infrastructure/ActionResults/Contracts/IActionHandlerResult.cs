namespace SmartConnect.Web.Infrastructure.ActionResults.Contracts
{
    using System.Web.Mvc;

    public interface IActionHandlerResult
    {
        ActionResult Success { get; }

        ActionResult Failure { get; }
    }
}
