using NexcoWeb.WebUI.Security;
using NexcoWeb.Domain.Concrete;
using NexcoWeb.WebUI.Models;
using Microsoft.Owin;
using System.Web;
using Microsoft.AspNet.Identity;
using System.Reflection;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.EntityFramework;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;




[assembly: WebActivator.PostApplicationStartMethod(typeof(NexcoWeb.WebUI.App_Start.SimpleInjectorInitializer), "Initialize")]

namespace NexcoWeb.WebUI.App_Start
{
    using System.Reflection;
    using System.Runtime.Remoting.Contexts;
    using System.Web;
    using System.Web.Mvc;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.Owin;
    using NexcoWeb.Domain.Abstract;
    using NexcoWeb.Domain.Entities;
    using SimpleInjector;
    using SimpleInjector.Integration.Web;
    using SimpleInjector.Integration.Web.Mvc;
    
    public static class SimpleInjectorInitializer
    {
        /// <summary>Initialize the container and register it as MVC3 Dependency Resolver.</summary>
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            InitializeContainer(container);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
     
        private static void InitializeContainer(Container container)
        {
            // For instance:
           // container.Register<IBudgetRepository, SqlUserRepository>(Lifestyle.Scoped);
            container.Register<EFDbContext>(Lifestyle.Scoped);
            container.Register<EFBudgetRepository>(Lifestyle.Scoped);
            container.Register<EFExpenditureRepository>(Lifestyle.Scoped);
            container.Register<EFIncomeRepository>(Lifestyle.Scoped); 
            container.Register<ApplicationUserManager>(Lifestyle.Scoped);
            container.Register<ApplicationSignInManager>(Lifestyle.Scoped);
           


            container.Register(() =>
    container.IsVerifying
        ? new OwinContext().Authentication
        : HttpContext.Current.GetOwinContext().Authentication,
    Lifestyle.Scoped);
            container.Register<IUserStore<User>>(() =>
        new UserStore<User>(container.GetInstance<EFDbContext>()),
        Lifestyle.Scoped);
        }
    }
}