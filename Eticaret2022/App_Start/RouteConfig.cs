using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Eticaret2022
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "SayfaBulunamadiHatasi",
                "sayfa-bulunamadi-hatasi",
                new { controller = "Error", action = "PageNotFound", id = UrlParameter.Optional },
                namespaces: new[] { "Eticaret2022.Controllers" }
            );

            routes.MapRoute(
                "SunucuHatasi",
                "sunucu-hatasi",
                new { controller = "Error", action = "ServerError", id = UrlParameter.Optional },
                namespaces: new[] { "Eticaret2022.Controllers" }
            );

            routes.MapRoute(
                "ErisimYetkisiHatasi",
                "erisim-yetkisi-hatasi",
                new { controller = "Error", action = "NoAccessPermission", id = UrlParameter.Optional },
                namespaces: new[] { "Eticaret2022.Controllers" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "Eticaret2022.Controllers" }
            );
        }
    }
}
