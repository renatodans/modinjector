using Microsoft.Extensions.DependencyInjection;
using ModInjector.Dependency;
using ModInjector.Modules;

namespace ModInjector.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddModInjectorServices<T>(this IServiceCollection services) where T : InjectorModule
        {
            IocManager.Instance.AddServices<T>(services);
        }
    }
}
