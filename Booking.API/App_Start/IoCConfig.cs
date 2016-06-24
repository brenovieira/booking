using System.Web.Http;
using Booking.DAL.Dao;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;

namespace Booking.API
{
    public class IoCConfig
    {
        public static void Register(HttpConfiguration httpConfig)
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();

            container.Register<IAccountDao, AccountDao>(Lifestyle.Transient);
            container.Register<IAvailabilityDao, AvailabilityDao>(Lifestyle.Transient);
            container.Register<IEventDao, EventDao>(Lifestyle.Transient);
            container.Register<IHealthIssueDao, HealthIssueDao>(Lifestyle.Transient);
            container.Register<IOrderDao, OrderDao>(Lifestyle.Transient);

            container.RegisterWebApiControllers(httpConfig);

            container.Verify();

            httpConfig.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}