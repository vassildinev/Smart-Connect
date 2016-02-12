namespace SmartConnect.Services.Identity
{
    using System;

    using Common;
    using Contracts;
    using Data;
    using Data.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity.Owin;
    using Microsoft.Owin;
    using Microsoft.Owin.Security.DataProtection;
    using Services.Common.Constants;
    using Services.Common.Helpers;

    public class IdentityService : UserManager<User>, IIdentityService
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

        public IdentityResult AddToRole(string userId, string roleName)
        {
            return AsyncHelper.RunSync(() => this.AddToRoleAsync(userId, roleName));
        }

        public IdentityResult CreateUser(User user, string password)
        {
            return AsyncHelper.RunSync(() => this.CreateAsync(user, password));
        }
    }
}
