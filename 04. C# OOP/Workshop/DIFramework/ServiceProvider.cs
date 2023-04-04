using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DIFramework.Contracts;
using IServiceProvider = System.IServiceProvider;

namespace DIFramework
{
    public class ServiceProvider : IServiceProvider
    {
        private IServiceCollection serviceCollection;
        public ServiceProvider(IServiceCollection serviceCollection)
        {
            this.serviceCollection = serviceCollection;
        }

        public object? GetService(Type serviceType)
        {
            throw new NotImplementedException();
        }
    }
}
