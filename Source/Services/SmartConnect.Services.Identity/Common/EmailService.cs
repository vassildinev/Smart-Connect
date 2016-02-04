namespace SmartConnect.Services.Identity.Common
{
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;
    using Services.Common.Constants;

    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            return Task.FromResult(IdentityServiceConstants.SendResult);
        }
    }
}
