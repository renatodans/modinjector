using ModInjector.Attributes;
using ModInjector.Modules;
using Sample.Core;

namespace Sample.Api
{
    [DependsOn(
       typeof(CoreModule)
   )]
    public class ApiModule : InjectorModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ApiModule).Assembly);
        }
    }
}
