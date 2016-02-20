namespace SmartConnect.Web.Identity
{
    using System;

    using Common.Constants;
    using Common.Helpers;
    using Data.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;
    using Microsoft.Owin.Security.DataProtection;

    public class SmartConnectUserManager : UserManager<User>
    {
        public SmartConnectUserManager(IUserStore<User> store)
            : base(store)
        {
            this.UserValidator = new UserValidator<User>(this)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = false
            };

            this.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false,
            };

            this.UserLockoutEnabledByDefault = true;
            this.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            this.MaxFailedAccessAttemptsBeforeLockout = 5;

            this.RegisterTwoFactorProvider(IdentityConstants.TwoFactorPhoneNumberProviderName, new PhoneNumberTokenProvider<User>
            {
                MessageFormat = "Your security code is {0}"
            });

            this.RegisterTwoFactorProvider(IdentityConstants.TwoFactorEmailNumberProviderName, new EmailTokenProvider<User>
            {
                Subject = "Security Code",
                BodyFormat = "Your security code is {0}"
            });
        }

        public SmartConnectUserManager(IUserStore<User> store, IdentityFactoryOptions<SmartConnectUserManager> options)
            : this(store)
        {
            IDataProtectionProvider dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                this.UserTokenProvider =
                    new DataProtectorTokenProvider<User>(dataProtectionProvider.Create(IdentityConstants.DataProtectionProviderPurpose));
            }
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
