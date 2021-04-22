using ModInjector.Attributes;
using ModInjector.Modules;
using Sample.Infrastructure;

namespace Sample.Api
{
    [DependsOn(        
       typeof(InfrastructureModule)
   )]
    public class ApiModule : InjectorModule
    {
        public override void PreInitialize()
        {
            
        }
    }
}
