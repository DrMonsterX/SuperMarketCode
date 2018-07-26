using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MySuperMarket
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "twoPara",
                url: "{controller}/{action}/{para01}/{para02}",
                defaults: new { controller = "Home", action = "Index", para01 = UrlParameter.Optional, para02 = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "threePara",
                url: "{controller}/{action}/{para01}/{para02}/{para03}",
                defaults: new { controller = "Home", action = "Index", para01 = UrlParameter.Optional, para02 = UrlParameter.Optional, para03 = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "fourPara",
                url: "{controller}/{action}/{para01}/{para02}/{para03}/{para04}",
                defaults: new { controller = "Home", action = "Index", para01 = UrlParameter.Optional, para02 = UrlParameter.Optional, para03 = UrlParameter.Optional, para04 = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "fivePara",
                url: "{controller}/{action}/{para01}/{para02}/{para03}/{para04}/{para05}",
                defaults: new { controller = "Home", action = "Index", para01 = UrlParameter.Optional, para02 = UrlParameter.Optional, para03 = UrlParameter.Optional, para04 = UrlParameter.Optional, para05 = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "sixPara",
                url: "{controller}/{action}/{para01}/{para02}/{para03}/{para04}/{para05}/{para06}",
                defaults: new { controller = "Home", action = "Index", para01 = UrlParameter.Optional, para02 = UrlParameter.Optional, para03 = UrlParameter.Optional, para04 = UrlParameter.Optional, para05 = UrlParameter.Optional, para06 = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "sevenPara",
                url: "{controller}/{action}/{para01}/{para02}/{para03}/{para04}/{para05}/{para06}/{para07}",
                defaults: new { controller = "Home", action = "Index", para01 = UrlParameter.Optional, para02 = UrlParameter.Optional, para03 = UrlParameter.Optional, para04 = UrlParameter.Optional, para05 = UrlParameter.Optional, para06 = UrlParameter.Optional, para07 = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "eightPara",
                url: "{controller}/{action}/{para01}/{para02}/{para03}/{para04}/{para05}/{para06}/{para07}/{para08}",
                defaults: new { controller = "Home", action = "Index", para01 = UrlParameter.Optional, para02 = UrlParameter.Optional, para03 = UrlParameter.Optional, para04 = UrlParameter.Optional, para05 = UrlParameter.Optional, para06 = UrlParameter.Optional, para07 = UrlParameter.Optional, para08 = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "ninePara",
                url: "{controller}/{action}/{para01}/{para02}/{para03}/{para04}/{para05}/{para06}/{para07}/{para08}/{para09}",
                defaults: new { controller = "Home", action = "Index", para01 = UrlParameter.Optional, para02 = UrlParameter.Optional, para03 = UrlParameter.Optional, para04 = UrlParameter.Optional, para05 = UrlParameter.Optional, para06 = UrlParameter.Optional, para07 = UrlParameter.Optional, para08 = UrlParameter.Optional, para09 = UrlParameter.Optional }
            );
        }
    }
}
