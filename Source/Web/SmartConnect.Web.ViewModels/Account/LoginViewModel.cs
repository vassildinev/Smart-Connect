namespace SmartConnect.Web.ViewModels.Account
{
    using Common;

    public class LoginViewModel : BasePageViewModel
    {
        public LoginUserViewModel User { get; set; }

        public string ReturnUrl { get; set; }
    }
}
