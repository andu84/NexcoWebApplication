
using NexcoWeb.Domain.Concrete;
using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Routing;


namespace NexcoWeb.WebUI
{

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer<EFDbContext>(null);
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
