using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIFramework.Contracts
{
    public interface IServiceCollection
    {
        void AddTransient<TInterface, TImplementation>();
        void AddTransient<TInterface, TImplementation>(Func<IServiceProvider, TImplementation> implementationFactory);
    }
}