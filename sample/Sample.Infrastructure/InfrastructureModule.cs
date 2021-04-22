using ModInjector.Attributes;
using ModInjector.Modules;
using Sample.Core;

namespace Sample.Infrastructure
{
    [DependsOn(
        typeof(CoreModule)        
    )]
    public class InfrastructureModule : InjectorModule
    {
    }
}
