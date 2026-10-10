using System;
using System.Collections.Generic;

namespace Assets._Digger.Scripts.Game.Root.DI
{
    public class DIContainer
    {
        private readonly Dictionary<Type, object> _services = new();

        public void Register<T>(T service)
        {
            _services[typeof(T)] = service;
        }

        public T Resolve<T>()
        {
            return (T)_services[typeof(T)];
        }
    }
}