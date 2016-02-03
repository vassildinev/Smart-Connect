namespace SmartConnect.Services.Identity
{
    using System;

    using Common;
    using Data;
    using Data.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity.Owin;
    using Microsoft.Owin;
    using Microsoft.Owin.Security.DataProtection;
    using SmartConnect.Common.Constants.Services;

    public class IdentityService : UserManager<User>
    {
        public IdentityService(IUserStore<User> store)
            : base(store)
        {
        }

        public static IdentityService Create(IdentityFactoryOptions<IdentityService> options, IOwinContext context)
        {
            SmartConnectDbContext smartConnectDbContext = context.Get<SmartConnectDbContext>();
            var userStore = new UserStore<User>(smartConnectDbContext);
            var manager = new IdentityService(userStore);

            manager.UserValidator = new UserValidator<User>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = false
            };

            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false,
            };

            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;

            manager.RegisterTwoFactorProvider(IdentityServiceConstants.TwoFactorPhoneNumberProviderName, new PhoneNumberTokenProvider<User>
            {
                MessageFormat = "Your security code is {0}"
            });

            manager.RegisterTwoFactorProvider(IdentityServiceConstants.TwoFactorEmailNumberProviderName, new EmailTokenProvider<User>
            {
                Subject = "Security Code",
                BodyFormat = "Your security code is {0}"
            });

            manager.EmailService = new EmailService();
            manager.SmsService = new SmsService();

            IDataProtectionProvider dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider =
                    new DataProtectorTokenProvider<User>(dataProtectionProvider.Create(IdentityServiceConstants.DataProtectionProviderPurpose));
            }

            return manager;
        }
    }
}
