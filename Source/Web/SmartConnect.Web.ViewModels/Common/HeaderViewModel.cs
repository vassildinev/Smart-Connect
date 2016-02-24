namespace SmartConnect.Web.ViewModels.Common
{
    public class HeaderViewModel
    {
        private const string DefaultBackgroundUrl = "../../Images/default-header-background.jpg";

        public string Heading { get; set; }

        public string BackgroundUrl { get; set; } = DefaultBackgroundUrl;

        public string SubHeading { get; set; }
    }
}
