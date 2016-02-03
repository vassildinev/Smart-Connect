namespace SmartConnect.Web.App
{
    using System.Web.Mvc;

    public static class ViewEnginesConfig
    {
        public static void RegisterViewEngines(ViewEngineCollection viewEngines)
        {
            viewEngines.Clear();

            var razor = new RazorViewEngine();
            viewEngines.Add(razor);
        }
    }
}