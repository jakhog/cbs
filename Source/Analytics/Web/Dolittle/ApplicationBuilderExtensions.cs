using Dolittle.Applications.Configuration;
using Dolittle.DependencyInversion;
using Microsoft.AspNetCore.Builder;

namespace Web.Dolittle
{
    public static class ApplicationBuilderExtensions
    {
        public static void UseDolittle(this IApplicationBuilder builder)
        {
            var container = (IContainer)builder.ApplicationServices.GetService(typeof(IContainer));

            var configurationBootProcedure = container.Get<BootProcedure>();

            System.Console.WriteLine("%%%%%%%% PERFORMING BOOT %%%%%%%%%%%%");
            configurationBootProcedure.Perform();
            System.Console.WriteLine("%%%%%%%% PERFORMED BOOT %%%%%%%%%%%%");
        }
    }
}