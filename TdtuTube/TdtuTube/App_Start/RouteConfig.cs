using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TdtuTube
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("Video", "{type}/{meta}",
                new { controller = "Video", action = "Index", meta = UrlParameter.Optional },
                new RouteValueDictionary
                {
                    { "type", "video" }
                },
                new[] { "TdtuTube.Controllers" }
            );

            routes.MapRoute("Feed", "{type}/{meta}",
                new { controller = "Feed", action = "Index", meta = UrlParameter.Optional },
                new RouteValueDictionary
                {
                    { "type", "feed" }
                },
                new[] { "TdtuTube.Controllers" }
            );

            routes.MapRoute("Channel", "{type}/{user}/{meta}",
                new { controller = "Channel", action = "Index", meta = UrlParameter.Optional },
                new RouteValueDictionary
                {
                    { "type", "channel" }
                },
                new[] { "TdtuTube.Controllers" }
            );

            routes.MapRoute("Watch", "{type}/{meta}",
                new { controller = "Watch", action = "Index", meta = UrlParameter.Optional },
                new RouteValueDictionary
                {
                    { "type", "watch" }
                },
                new[] { "TdtuTube.Controllers" }
            );
            routes.MapRoute("Button", "{type}/{action}/{meta}",
                new { controller = "Button", action = "Index", meta = UrlParameter.Optional },
                new RouteValueDictionary
                {
                    { "type", "button" }
                },
                new[] { "TdtuTube.Controllers" }
            );

            routes.MapRoute("Search", "{type}",
                new { controller = "Search", action = "Index" },
                new RouteValueDictionary
                {
                    { "type", "search" }
                },
                new[] { "TdtuTube.Controllers" }
            );

            routes.MapRoute("Login", "{type}",
                new { controller = "Login", action = "Index"},
                new RouteValueDictionary
                {
                    { "type", "login" }
                },
                new[] { "TdtuTube.Controllers" }
            );

            routes.MapRoute("Studio", "{type}/{action}/{meta}",
                new { controller = "Studio", action = "Index", meta = UrlParameter.Optional },
                new RouteValueDictionary
                {
                    { "type", "studio" }
                },
                new[] { "TdtuTube.Controllers" }
            );

            routes.MapRoute("Home", "{controller}/{action}/{meta}",
                new { controller = "Home", action = "Index", meta = UrlParameter.Optional }
            );
        }
    }
}
