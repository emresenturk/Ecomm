using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Ecomm.Catalog;
using Ecomm.Catalog.DataProviders.Xml;
using Ecomm.Catalog.Providers;
using Ecomm.Commerce;
using Ecomm.Web.Models;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using SimpleInjector.Integration.WebApi;

namespace Ecomm.Web
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
            RegisterServices(container);
            container.Verify();
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }

        private static void RegisterServices(Container container)
        {
            container.RegisterSingleton<ICatalogDataProviderFactory, XmlCatalogDataProdivderFactory>();
            container.RegisterSingleton<ICatalogService, CatalogService>();
            container.RegisterSingleton<ICommerceService>(() =>
            {
                return new CommerceService(() => new ApplicationDbContext());
            });
        }
    }
}
