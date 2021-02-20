using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace enesatac_site
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapMvcAttributeRoutes();
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new[] {"enesatac_site.Controllers"}
            );

            routes.MapRoute(
                "404-sayfa-bulunamadi",
            "{*url}",
            new { controller = "StaticContent", action = "PageNotFound" }
            );
        }

       
    }

}
