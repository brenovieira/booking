using System.Web.Http;
using Booking.DAL;
using Booking.DAL.Dao;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using System.Configuration;

namespace Booking.API
{
    public class IoCConfig
    {
        public static void Register(HttpConfiguration httpConfig)
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();

            var connectionString = ConfigurationManager.AppSettings["DBContext"];
            container.Register(() => new DBContext(connectionString), Lifestyle.Scoped);
            container.Register<IAvailabilityDao, AvailabilityDao>();
            container.Register<IEventDao, EventDao>();
            container.Register<IHealthIssueDao, HealthIssueDao>();
            container.Register<IOrderDao, OrderDao>();

            container.RegisterWebApiControllers(httpConfig);

            container.Verify();

            httpConfig.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}