namespace SmartConnect.Web.Controllers.Contracts
{
    using System;
    using System.Web.Mvc;
    using System.Web.Routing;

    using Contracts;
    using Data.Models;

    [Authorize]
    public class BaseAuthorizationController : BaseController
    {
        protected User CurrentUser { get; private set; }

        protected override IAsyncResult BeginExecute(RequestContext requestContext, AsyncCallback callback, object state)
        {
            if (this.CurrentUser == null)
            {
                // this.data.Users
            }

            return base.BeginExecute(requestContext, callback, state);
        }
    }
}
