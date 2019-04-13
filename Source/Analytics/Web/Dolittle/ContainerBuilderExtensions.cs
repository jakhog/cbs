using Autofac;
using Dolittle.DependencyInversion.Autofac;
using IContainer = Dolittle.DependencyInversion.IContainer;
using Read;
using Dolittle.Booting;
using Dolittle.Logging;
using System;
using Dolittle.Build;

namespace Web.Dolittle
{
    public class LogAppender : ILogAppender
    {
        public void Append(string filePath, int lineNumber, string member, LogLevel level, string message, Exception exception = null)
        {
            Console.WriteLine(message);
        }
    }

    public static class ContainerBuilderExtensions
    {
        public static void AddDolittle(this ContainerBuilder builder)
        {
            var booting = Bootloader.Configure(_ => {
                _.UseLogAppender(new LogAppender());
                _.SkipBootprocedures();
                _.UseContainer<Container>();
            });
            var results = booting.Start();
            foreach (var type in results.TypeFinder.All)
            {
                //Console.WriteLine($"!! Loaded type {type.FullName}");
            }


            foreach (var assembl in results.Assemblies.GetAll())
            {
                Console.WriteLine($"!! Loaded assembly {assembl.FullName}");
            }

            builder.AddDolittle(results.Assemblies, results.Bindings);
        }
    }
}
