namespace SmartConnect.Web.Infrastructure.ActionResults.Contracts
{
    public interface IActionHandlerWithModel<T>
    {
        T Handle();
    }
}
