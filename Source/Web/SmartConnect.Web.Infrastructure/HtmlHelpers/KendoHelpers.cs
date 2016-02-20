namespace SmartConnect.Web.Infrastructure.HtmlHelpers
{
    using System;
    using System.Linq.Expressions;
    using System.Web.Mvc;

    using Kendo.Mvc.UI;
    using Kendo.Mvc.UI.Fluent;

    public static class KendoHelpers
    {
        private const string GridName = "KendoDataGrid";

        public static GridBuilder<T> FullFeaturedGrid<T>(this HtmlHelper helper, string controllerName, Expression<Func<T, object>> modelIdExpression, object routeValues = null, Action<GridColumnFactory<T>> columns = null) where T : class
        {
            if (columns == null)
            {
                columns = cols =>
                {
                    cols.AutoGenerate(true);
                    cols.Command(c => c.Edit());
                    cols.Command(c => c.Destroy());
                };
            }

            return helper.Kendo()
                .Grid<T>()
                .Name(GridName)
                .Columns(columns)
                .ColumnMenu()
                .Pageable(page => page.Refresh(true))
                .Sortable()
                .Groupable()
                .Filterable()
                .Editable(edit => edit.Mode(GridEditMode.PopUp))
                .ToolBar(toolbar => toolbar.Create())
                .DataSource(data =>
                    data
                        .Ajax()
                        .Model(m => m.Id(modelIdExpression))
                        .Read(read => read.Action("Read", controllerName, routeValues))
                        .Create(create => create.Action("Create", controllerName, routeValues))
                        .Update(update => update.Action("Update", controllerName, routeValues))
                        .Destroy(destroy => destroy.Action("Destroy", controllerName, routeValues)));
        }
    }
}
