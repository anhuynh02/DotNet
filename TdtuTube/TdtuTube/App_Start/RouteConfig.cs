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

            routes.MapRoute("Channel", "{type}/{user}/{meta}",
                new { controller = "Channel", action = "Index", meta = UrlParameter.Optional },
                new RouteValueDictionary
                {
                    { "type", "channel" }
                },
                new[] { "TdtuTube.Controllers" }
            );
            //Route for watch controller
            routes.MapRoute("Watch", "{type}/{meta}",
                new { controller = "Watch", action = "Index", meta = UrlParameter.Optional },
                new RouteValueDictionary
                {
                    { "type", "watch" }
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

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
