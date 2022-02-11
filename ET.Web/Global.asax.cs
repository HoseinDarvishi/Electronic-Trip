using Autofac;
using Autofac.Integration.Mvc;
using ET.IoC;
using System.Configuration;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ET.Web
{
   public class MvcApplication : System.Web.HttpApplication
   {
      protected void Application_Start()
      {
         #region Dependency Injection Configs By Autofac
         var autofac = new ETBootstrapper();
         autofac.Container().RegisterControllers(typeof(MvcApplication).Assembly);
         autofac.Container().RegisterFilterProvider();
         autofac.Container().RegisterSource(new ViewRegistrationSource());
         autofac.Configure(ConfigurationManager.ConnectionStrings["ElectronicTrip"].ConnectionString);
         autofac.Resolve(); 
         #endregion

         AreaRegistration.RegisterAllAreas();
         FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
         RouteConfig.RegisterRoutes(RouteTable.Routes);
         BundleConfig.RegisterBundles(BundleTable.Bundles);
      }
   }
}