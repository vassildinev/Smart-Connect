namespace SmartConnect.Web.Controllers.Contracts
{
    using System;
    using System.Web.Mvc;
    using System.Web.Routing;

    using Data.Models;
    using Microsoft.AspNet.Identity;
    using Services.Common.Contracts;

    [Authorize]
    public abstract class BaseAuthorizationController : BaseController
    {
        public BaseAuthorizationController(IDataService<User, string> users)
        {
            this.Users = users;
        }

        protected IDataService<User, string> Users { get; private set; }

        protected User CurrentUser { get; private set; }

        protected override IAsyncResult BeginExecute(RequestContext requestContext, AsyncCallback callback, object state)
        {
            if (this.CurrentUser == null)
            {
                if (this.User != null)
                {
                    string userId = this.User.Identity.GetUserId();
                    User user = this.Users.GetById(userId);
                    this.CurrentUser = user;
                }
            }

            return base.BeginExecute(requestContext, callback, state);
        }
    }
}
