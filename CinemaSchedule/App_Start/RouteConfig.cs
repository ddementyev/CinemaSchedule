using System.Web.Mvc;
using System.Web.Routing;

namespace CinemaSchedule
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Cinema",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Cinema", action = "Sessions", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}

