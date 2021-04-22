using Microsoft.Extensions.DependencyInjection;
using ModInjector.Attributes;
using ModInjector.Dependency.IoC;
using ModInjector.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ModInjector.Dependency
{
    public class IocManager : IIocManager
    {
        public static IocManager Instance { get; private set; }

        private readonly List<Assembly> _assemblies = new List<Assembly>();

        static IocManager()
        {
            Instance = new IocManager();
        }

        internal void AddServices<T>(IServiceCollection services) where T : InjectorModule
        {
            var modules = InjectorModule.FindDependedModuleTypesRecursivelyIncludingGivenModule(typeof(T));

            foreach (var m in modules)
            {
                var d = m.GetCustomAttribute(typeof(DependsOnAttribute));


            }





            // Code Tests

            //T module = Activator.CreateInstance<T>();
            //module.IocManager = Instance;
            //module.Initialize();

            //if (services == null)
            //    throw new ArgumentNullException(nameof(services));


            //var types = _assemblies.FirstOrDefault().GetTypes().Where(p => typeof(ITransientDependency).IsAssignableFrom(p)).ToArray();

            //var addTransientMethod = typeof(ServiceCollectionServiceExtensions).GetMethods().FirstOrDefault(m =>
            //    m.Name == "AddTransient" &&
            //    m.IsGenericMethod == true &&
            //    m.GetGenericArguments().Count() == 2);

            //Type inter = null;
            //foreach (var type in types)
            //{
            //    if (type.IsInterface)
            //    {
            //        inter = type;
            //        continue;
            //    }


            //    var method = addTransientMethod.MakeGenericMethod(new[] { inter, type });
            //    method.Invoke(services, new[] { services });
            //}
        }

        public void RegisterAssemblyByConvention(Assembly assembly)
        {
            _assemblies.Add(assembly);
        }

        public void Dispose()
        {
            Instance.Dispose();
        }
    }
}