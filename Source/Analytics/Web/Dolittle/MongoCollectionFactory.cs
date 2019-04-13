using Dolittle.DependencyInversion;
using Dolittle.ResourceTypes.Configuration;
using Configuration = Dolittle.ReadModels.MongoDB.Configuration;
using MongoDB.Driver;
using Read;
using Dolittle.Execution;
using Dolittle.Tenancy;
using Dolittle.Types;
using Dolittle.ResourceTypes;

namespace Web.Dolittle
{
    public class MongoCollectionFactory : IMongoCollectionFactory
    {
        readonly IExecutionContextManager _executionContextManager;
        readonly IConfigurationFor<Configuration> _configuration;
        readonly IContainer _container;

        public MongoCollectionFactory(
            IExecutionContextManager executionContextManager,
            //IConfigurationFor<Configuration> configuration
            IContainer container
        )
        {
            System.Console.WriteLine($"!!!!!!! Constructor ");
            _container = container;
            _executionContextManager = executionContextManager;
            //_configuration = configuration;
        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            System.Console.WriteLine($"!!!!!!! CREATING COLLECTIONS ");

            _executionContextManager.CurrentFor(TenantId.Development);
            var config = _container.Get<IConfigurationFor<Configuration>>();

            System.Console.WriteLine(config);

            //var configuration = _configuration.Instance;
            //return configuration.Database.GetCollection<T>(name);
            return null;
        }
    }
}