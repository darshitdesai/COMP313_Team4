using CabBook.Data;
using CabBook.Web.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using UtilFilters;

namespace CabBook.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public class FilterConfig
        {
            public static void RegisterGlobalFilters(GlobalFilterCollection filters)
            {
                filters.Add(new HandleErrorAttribute());
                filters.Add(new System.Web.Mvc.AuthorizeAttribute());
            }
        }

        protected void Application_Start()
        {
            // Init database

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            System.Data.Entity.Database.SetInitializer(new StoreSeedData());


            // Autofac and Automapper configurations
            Bootstrapper.Run();


        }

    }
}
