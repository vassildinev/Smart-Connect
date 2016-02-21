namespace SmartConnect.Web.Areas.Admin.Quotes
{
    using System.Web.Mvc;
    
    public class AdminQuotesAreaRegistration : AreaRegistration
    {
        public override string AreaName => "Admin/Quotes";

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "AdminQuotes",
                "Admin/Quotes/{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "SmartConnect.Web.Controllers.Admin.Quotes" }
            );
        }
    }
}
