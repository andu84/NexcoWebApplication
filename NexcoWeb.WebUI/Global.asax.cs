
using NexcoWeb.Domain.Concrete;
using NexcoWeb.WebUI.App_Start;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Optimization;



namespace NexcoWeb.WebUI
{

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // Register Web API routing support before anything else
            GlobalConfiguration.Configure(WebApiConfig.Register);
            Database.SetInitializer<EFDbContext>(null);
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);          
      
        }
    }
}
