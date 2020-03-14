using System;
using System.Collections.Generic;
using System.Linq;

namespace Verivox.TariffComparer.Infrastructure
{
    //SOURCE: https://github.com/rlbisbe/YetAnotherDependencyInjector/blob/master/YetAnotherDependencyInjector/Injector.cs

    public class Injector
    {
        private static Dictionary<Type, Type> typeMappings = new Dictionary<Type, Type>();
        private static Dictionary<Type, Func<object>> funcMappings = new Dictionary<Type, Func<object>>();

        public static T Get<T>()
        {
            var type = typeof(T);
            return (T)Get(type);
        }

        private static object Get(Type type)
        {
            if (funcMappings.ContainsKey(type))
            {
                return funcMappings[type]();
            }

            var target = ResolveType(type);
            var constructor = target.GetConstructors()[0];
            var parameters = constructor.GetParameters();

            List<object> resolvedParameters = new List<object>();

            foreach (var item in parameters)
            {
                resolvedParameters.Add(Get(item.ParameterType));
            }

            return constructor.Invoke(resolvedParameters.ToArray());
        }

        private static Type ResolveType(Type type)
        {
            if (typeMappings.Keys.Contains(type))
            {
                return typeMappings[type];
            }

            return type;
        }

        public static void Map<T, V>() where V : T
        {
            typeMappings.Add(typeof(T), typeof(V));
        }

        public static void Map<T>()
        {
            typeMappings.Add(typeof(T), typeof(T));
        }

        public static void Map<T>(Func<object> dependencyFunction)
        {
            funcMappings.Add(typeof(T), dependencyFunction);
        }

        public static void Clear()
        {
            typeMappings.Clear();
            funcMappings.Clear();
        }
    }
}
