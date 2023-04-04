using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIFramework.Contracts
{
    public interface IServiceProvider
    {
        object GetService(Type serviceType);
    }
}
