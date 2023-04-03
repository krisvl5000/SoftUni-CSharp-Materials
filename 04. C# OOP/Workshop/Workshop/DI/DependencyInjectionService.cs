using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Workshop.Drawers;
using Workshop.Drawers.Contracts;

namespace Workshop.DI
{
    internal class DependencyInjectionService
    {
        public static IServiceProvider ConfigureServices()
        {
            IServiceCollection serviceCollection = new ServiceCollection();

            // custom code
            serviceCollection.AddTransient<IShapeDrawer, BasicShapeDrawer>();
            serviceCollection.AddTransient<Engine, Engine>();

            return serviceCollection.BuildServiceProvider();
        }
    }
}
