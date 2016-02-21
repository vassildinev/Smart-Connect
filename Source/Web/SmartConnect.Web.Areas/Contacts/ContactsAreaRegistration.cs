namespace SmartConnect.Web.Areas.Contacts
{
    using System.Web.Mvc;

    public class ContactsAreaRegistration : AreaRegistration
    {
        public override string AreaName => "Contacts";

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Contacts",
                "Contacts/{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "SmartConnect.Web.Controllers.Contacts" }
            );
        }
    }
}
