namespace SmartConnect.Services.Identity.Common
{
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;
    using SmartConnect.Common.Constants.Services;

    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            return Task.FromResult(IdentityServiceConstants.SendResult);
        }
    }
}
