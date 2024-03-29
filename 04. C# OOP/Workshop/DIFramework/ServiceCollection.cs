﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIFramework.Contracts
{
    public class ServiceCollection : IServiceCollection
    {
        private Dictionary<Type, Type> mappings;

        public ServiceCollection()
        {
            mappings = new Dictionary<Type, Type>();
        }

        public void AddTransient<TInterface, TImplementation>()
        {
            mappings.Add(typeof(TInterface), typeof(TImplementation));
        }

        public void AddTransient<TInterface, TImplementation>(Func<IServiceProvider, TImplementation> implementationFactory)
        {
            throw new NotImplementedException();
        }

        public Type GetMapping(Type interfaceType)
        {
            if (mappings.ContainsKey(interfaceType))
            {
                throw new ArgumentException($"Mapping for interfaceType {interfaceType.Name} has not been configured");
            }

            return mappings[interfaceType];
        }
    }
}