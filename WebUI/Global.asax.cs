using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using BusStation.Services.Ninject;
using Ninject;
using Ninject.Web.Mvc;

namespace WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //registration ninjectbindins
            NinjectBindings ninjectBindings = new NinjectBindings("BusStationDbConnection");
            var kernel = new StandardKernel(ninjectBindings);
            kernel.Unbind<ModelValidatorProvider>();
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}
