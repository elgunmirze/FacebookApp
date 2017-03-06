using System.Web.Mvc;
using System.Web.Routing;

namespace FacebookLoginApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                new {controller = "FacebookAuth", action = "LoginPage", id = UrlParameter.Optional}
            );
        }
    }
}