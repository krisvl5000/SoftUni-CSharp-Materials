using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
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

            return serviceCollection.BuildServiceProvider();
        }
    }
}
