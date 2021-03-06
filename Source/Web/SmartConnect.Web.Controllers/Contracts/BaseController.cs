﻿namespace SmartConnect.Web.Controllers.Contracts
{
    using System.Web.Mvc;

    using Infrastructure.ActionResults;
    using System.Web;
    using System.Web.Routing;
    using System;
    using AutoMapper;
    using Infrastructure.Mappings;
    using Kendo.Mvc.UI;
    using Kendo.Mvc.Extensions;
    using System.Collections.Generic;

    public abstract class BaseController : Controller
    {
        protected IMapper Mapper
        {
            get
            {
                return StandardMapperObjectsProvider.MapperConfiguration.CreateMapper();
            }
        }

        protected override IAsyncResult BeginExecute(RequestContext requestContext, AsyncCallback callback, object state)
        {
            return base.BeginExecute(requestContext, callback, state);
        }

        [NonAction]
        protected AutoMappedObjectResult<TSource, TResult> AutoMappedObjectView<TSource, TResult>(ViewResult view)
            where TSource : class
        {
            return new AutoMappedObjectResult<TSource, TResult>(view, this.Mapper);
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            if (filterContext.ExceptionHandled)
            {
                return;
            }

            if (this.Request.IsAjaxRequest())
            {
                var exception = filterContext.Exception as HttpException;

                if (exception != null)
                {
                    this.Response.StatusCode = exception.GetHttpCode();
                    this.Response.StatusDescription = exception.Message;
                }
            }
            else
            {
                var controllerName = ControllerContext.RouteData.Values["controller"].ToString();
                var actionName = ControllerContext.RouteData.Values["action"].ToString();
                this.View("Error", new HandleErrorInfo(filterContext.Exception, controllerName, actionName)).ExecuteResult(this.ControllerContext);
            }

            filterContext.ExceptionHandled = true;
        }

        [NonAction]
        protected JsonResult ObjectGridResult<TViewModel>([DataSourceRequest]DataSourceRequest request, TViewModel model)
        {
            return Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }

        [NonAction]
        protected JsonResult CollectionGridResult<TViewModel>([DataSourceRequest]DataSourceRequest request, IEnumerable<TViewModel> data)
        {
            return Json(data.ToDataSourceResult(request));
        }

        [NonAction]
        protected AutoMappedQueryViewResult<TSource, TResult> AutoMappedQueryView<TSource, TResult>(ViewResult view)
        {
            return new AutoMappedQueryViewResult<TSource, TResult>(view);
        }

        [NonAction]
        protected ActionHandlerResult<TData> ActionHandlerFor<TData>(ActionResult success, TData data = null)
            where TData : class
        {
            return this.ActionHandlerFor(success, null, data);
        }

        [NonAction]
        protected ActionHandlerResult<TData> ActionHandlerFor<TData>(ActionResult success, ActionResult failure = null, TData data = null)
            where TData : class
        {
            return new ActionHandlerResult<TData>(data, success, failure);
        }

        [NonAction]
        protected ActionHandlerWithModelResult<TData> ActionHandlerWithModelFor<TData>(ActionResult success, ActionResult failure = null)
            where TData : class
        {
            return new ActionHandlerWithModelResult<TData>(success, failure);
        }

        [NonAction]
        protected PostedDataResultActionHandlerResult<TData> PostedDataActionHandlerFor<TData>(TData data, ActionResult success, ActionResult failure)
            where TData : class
        {
            return new PostedDataResultActionHandlerResult<TData>(data, success, failure);
        }
    }
}
