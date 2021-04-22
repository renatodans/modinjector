using ModInjector.Attributes;
using ModInjector.Dependency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ModInjector.Modules
{
    public abstract class InjectorModule
    {
        protected internal IIocManager IocManager { get; internal set; }

        

        public static bool IsInjectorModule(Type type)
        {
            var typeInfo = type.GetTypeInfo();
            return
                typeInfo.IsClass &&
                !typeInfo.IsAbstract &&
                !typeInfo.IsGenericType &&
                typeof(InjectorModule).IsAssignableFrom(type);
        }

        public virtual void PreInitialize()
        {
        }

        public virtual void Initialize()
        {
        }

        public virtual void PostInitialize()
        {
        }

        public static List<Type> FindDependedModuleTypes(Type moduleType)
        {
            if (!IsInjectorModule(moduleType))
                throw new Exception("This type is not an ModInjector module: " + moduleType.AssemblyQualifiedName);

            var list = new List<Type>();

            if (moduleType.GetTypeInfo().IsDefined(typeof(DependsOnAttribute), true))
            {
                var dependsOnAttributes = moduleType.GetTypeInfo().GetCustomAttributes(typeof(DependsOnAttribute), true).Cast<DependsOnAttribute>();
                foreach (var dependsOnAttribute in dependsOnAttributes)
                {
                    foreach (var dependedModuleType in dependsOnAttribute.DependedModuleTypes)
                    {
                        list.Add(dependedModuleType);
                    }
                }
            }

            return list;
        }

        public static List<Type> FindDependedModuleTypesRecursivelyIncludingGivenModule(Type moduleType)
        {
            var list = new List<Type>();
            AddModuleAndDependenciesRecursively(list, moduleType);

            //list.AddIfNotContains(typeof(KernelModule));

            return list;
        }

        private static void AddModuleAndDependenciesRecursively(List<Type> modules, Type module)
        {
            if (!IsInjectorModule(module))
                throw new Exception("This type is not an ModInjector module: " + module.AssemblyQualifiedName);

            if (modules.Contains(module))
                return;

            modules.Add(module);

            var dependedModules = FindDependedModuleTypes(module);
            foreach (var dependedModule in dependedModules)
            {
                AddModuleAndDependenciesRecursively(modules, dependedModule);
            }
        }
    }
}
