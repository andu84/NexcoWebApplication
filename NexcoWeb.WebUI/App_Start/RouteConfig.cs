﻿using System.Web.Mvc;
using System.Web.Routing;

namespace NexcoWeb.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(null, "",
                new
                {
                    controller = "Budget",
                    action = "List",
                    description = (string)null,
                    page = 1

                });
            routes.MapRoute(null, "Page{page}",
               new
               {
                   controller = "Budget",
                   action = "List",
                   description = (string)null,
               },
               new { page = @"\d+" });

            routes.MapRoute(null,
                "{description}",
                new { controller = "Budget", action = "List", page = 1 }
                );



            routes.MapRoute(null,
                "{description}/Page{page}",
                new { controller = "Budget", action = "List" },
                new { page = @"\d+" }
                );



            routes.MapRoute(null, "{controller}/{action}");
        }
    }
}
