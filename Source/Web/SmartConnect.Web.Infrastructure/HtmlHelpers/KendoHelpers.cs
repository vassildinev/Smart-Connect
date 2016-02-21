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

        public static GridBuilder<TViewModel> FullFeaturedGrid<TViewModel>(this HtmlHelper helper, string controllerName, Expression<Func<TViewModel, object>> modelIdExpression, object routeValues = null, Action<GridColumnFactory<TViewModel>> columns = null) where TViewModel : class
        {
            if (columns == null)
            {
                columns = cols =>
                {
                    cols.AutoGenerate(true);
                    cols.Command(c =>
                    {
                        c.Edit();
                        c.Destroy().Text("(Un)Delete");
                    })
                    .Title("Modify");
                };
            }

            return helper.Kendo()
                .Grid<TViewModel>()
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

        public static GridBuilder<TViewModel> FullFeaturedGridWithEditorTemplate<TViewModel>(this HtmlHelper helper, string controllerName, Expression<Func<TViewModel, object>> modelIdExpression, string editorTemplateName, object routeValues = null, Action<GridColumnFactory<TViewModel>> columns = null) 
            where TViewModel : class
        {
            if (columns == null)
            {
                columns = cols =>
                {
                    cols.AutoGenerate(true);
                    cols.Command(c =>
                    {
                        c.Edit();
                        c.Destroy().Text("(Un)Delete");
                    })
                    .Title("Modify");
                };
            }

            return helper.Kendo()
                .Grid<TViewModel>()
                .Name(GridName)
                .Columns(columns)
                .ToolBar(toolbar => toolbar.Create())
                .ColumnMenu()
                .Pageable(page => page.Refresh(true))
                .Sortable()
                .Groupable()
                .Filterable()
                .Editable(edit => edit.Mode(GridEditMode.PopUp).TemplateName(editorTemplateName))
                .DataSource(data =>
                    data
                        .Ajax()
                        .Model(m => m.Id(modelIdExpression))
                        .Create(create => create.Action("Creates", controllerName, routeValues))
                        .Read(read => read.Action("Read", controllerName, routeValues))
                        .Update(update => update.Action("Update", controllerName, routeValues))
                        .Destroy(destroy => destroy.Action("Destroy", controllerName, routeValues)));
        }

        public static GridBuilder<TViewModel> NoCreateGridWithEditorTemplate<TViewModel>(this HtmlHelper helper, string controllerName, Expression<Func<TViewModel, object>> modelIdExpression, string editorTemplateName, object routeValues = null, Action<GridColumnFactory<TViewModel>> columns = null) 
            where TViewModel : class
        {
            if (columns == null)
            {
                columns = cols =>
                {
                    cols.AutoGenerate(true);
                    cols.Command(c =>
                    {
                        c.Edit();
                        c.Destroy().Text("(Un)Delete");
                    })
                    .Title("Modify");
                };
            }

            return helper.Kendo()
                .Grid<TViewModel>()
                .Name(GridName)
                .Columns(columns)
                .ColumnMenu()
                .Pageable(page => page.Refresh(true))
                .Sortable()
                .Groupable()
                .Filterable()
                .Editable(edit => edit.Mode(GridEditMode.PopUp).TemplateName(editorTemplateName))
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
