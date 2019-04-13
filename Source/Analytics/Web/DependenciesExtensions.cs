using Microsoft.Extensions.DependencyInjection;
using Web.Controllers;
using Read.CaseReports;
using Read;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Read.KPI;
using Read.HealthRisks;
using Read.DataCollectors;
using Read.Alerts;
using Web.Dolittle;

namespace Web
{
    public static class DependenciesExtensions
    {
        static IContainer _container;

        public static AutofacServiceProvider RegisterDependencies(this IServiceCollection services)
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterType<AnalysisService>();
            containerBuilder.RegisterType<MongoDBHandler>();
            containerBuilder.RegisterType<KPIRepository>();
            containerBuilder.RegisterType<HealthRisksEventHandler>().As<IHealthRisksEventHandler>();
            containerBuilder.RegisterType<CaseReportsEventHandler>().As<ICaseReportsEventHandler>();
            containerBuilder.RegisterType<DataCollectorEventHandler>().As<IDataCollectorsEventHandler>();
            containerBuilder.RegisterType<AlertEventHandler>().As<IAlertEventHandler>();
            containerBuilder.Populate(services);

            containerBuilder.Register(_ => _container);
            containerBuilder.AddDolittle();

            _container = containerBuilder.Build();
            return new AutofacServiceProvider(_container);
        }
    }
}
