﻿using Kendo.Mvc.UI;
using SmartConnect.Data.Models.Contracts;
using SmartConnect.Services.Common.Contracts;
using System.Web.Mvc;

namespace SmartConnect.Web.Controllers.Contracts
{
    public interface IKendoGridController<TModel, TViewModel, TKey>
        where TModel : class, IEntity<TKey>
        where TViewModel : class
    {
        IDataService<TModel, TKey> Data { get; }

        ActionResult Create([DataSourceRequest]DataSourceRequest request, TViewModel model);

        ActionResult Read([DataSourceRequest]DataSourceRequest request);

        ActionResult Update([DataSourceRequest]DataSourceRequest request, TViewModel viewModel);

        ActionResult Destroy([DataSourceRequest]DataSourceRequest request, TViewModel model);
    }
}
