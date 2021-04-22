using Microsoft.Extensions.DependencyInjection;
using ModInjector.Dependency.IoC;
using ModInjector.Modules;
using System;
using System.Linq;

namespace ModInjector.Dependency
{
    public class IocManager : IIocManager
    {
        public static IocManager Instance { get; private set; }

        //protected internal IStartupConfiguration Configuration { get; }        

        static IocManager()
        {
            Instance = new IocManager();
        }

        internal void AddServices<T>(IServiceCollection services) where T : InjectorModule
        {
            var modules = InjectorModule.FindDependedModuleTypesRecursivelyIncludingGivenModule(typeof(T));

            for (int i = modules.Count - 1; i >= 0; i--)
            {
                var module = Activator.CreateInstance(modules[i]) as InjectorModule;
                module.PreInitialize();
                module.PostInitialize();

                modules[i].Assembly.GetTypes()
                   .Where(item => item.GetInterfaces()
                   .Any(i => typeof(ITransientDependency).IsAssignableFrom(i) && i != typeof(ITransientDependency)))
                   .ToList()
                   .ForEach(assignedTypes =>
                   {
                       var serviceType = assignedTypes.GetInterfaces().First(i => typeof(ITransientDependency).IsAssignableFrom(i));
                       services.AddTransient(serviceType, assignedTypes);
                   });
            }
        }

        public void Dispose()
        {
            Instance.Dispose();
        }
    }
}