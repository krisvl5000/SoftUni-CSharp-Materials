using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildFarm
{
    public interface IFeline : IMammal
    {
        string Breed { get; }
    }
}
