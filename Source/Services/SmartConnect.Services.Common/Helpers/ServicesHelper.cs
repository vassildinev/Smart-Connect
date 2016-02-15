namespace SmartConnect.Services.Common.Helpers
{
    public static class ServicesHelper
    {
        public static string GetNullDependencyMessage(string dependencyName)
        {
            return $"{dependencyName} cannot be null";
        }
    }
}
