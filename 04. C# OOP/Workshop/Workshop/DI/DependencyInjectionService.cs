using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Workshop.Common;
using Workshop.Drawers;
using Workshop.Drawers.Contracts;
using Workshop.Renderers;

namespace Workshop.DI
{
    internal class DependencyInjectionService
    {
        public static IServiceProvider ConfigureServices()
        {
            IServiceCollection serviceCollection = new ServiceCollection();

            // custom code
            serviceCollection.AddTransient<IShapeDrawer, AdvancedShapeDrawer>();
            serviceCollection.AddTransient<Engine, Engine>();
            serviceCollection.AddTransient<IRenderer, ConsoleRenderer>();

            //serviceCollection.AddTransient<ILogger, DateLogger>((s ) =>
            //{
            //    return new DateLogger(5, 5, 2025);
            //});

            serviceCollection.AddSingleton<ILogger, Logger>(); // when it is singleton, it creates only one instance and always passes it, otherwise it always creates a new instance

            return serviceCollection.BuildServiceProvider();
        }
    }
}
