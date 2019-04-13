using Autofac.Core;
using Dolittle.DependencyInversion;
using Read;

namespace Web.Dolittle
{
    public class Bindings : ICanProvideBindings
    {
        public void Provide(IBindingProviderBuilder builder)
        {
            builder.Bind<IMongoCollectionFactory>().To<MongoCollectionFactory>();
        }
    }
}