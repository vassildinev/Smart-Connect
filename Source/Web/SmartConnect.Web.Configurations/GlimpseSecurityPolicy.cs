namespace SmartConnect.Web.Configurations
{
    using Extensions;
    using Glimpse.AspNet.Extensions;
    using Glimpse.Core.Extensibility;

    public class GlimpseSecurityPolicy : IRuntimePolicy
    {
        public RuntimeEvent ExecuteOn => RuntimeEvent.EndRequest | RuntimeEvent.ExecuteResource;

        public RuntimePolicy Execute(IRuntimePolicyContext policyContext)
        {
            var httpContext = policyContext.GetHttpContext();
            return httpContext.User.IsAdmin() ? RuntimePolicy.On : RuntimePolicy.Off;
        }
    }
}
