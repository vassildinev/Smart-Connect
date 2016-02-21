namespace SmartConnect.Web.Areas.Deals
{
    using System.Web.Mvc;

    public class DealsAreaRegistration : AreaRegistration
    {
        public override string AreaName => "Deals";

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Deals",
                "Deals/{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "SmartConnect.Web.Controllers.Deals" }
            );
        }
    }
}
