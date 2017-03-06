using System.Configuration;
using System.Diagnostics.CodeAnalysis;
using System.Web;
using FacebookApp.Interfaces.Facades;

namespace FacebookApp.Services.Facades
{
    [ExcludeFromCodeCoverage]
    public class CommonFacade : ICommonFacade
    {
        public string GetAppSettings(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
        public void SetToSession(string key, object value)
        {
            HttpContext.Current.Session[key] = value;
        }
        public object GetFromSession(string key)
        {
            return HttpContext.Current.Session[key];
        }
    }
}