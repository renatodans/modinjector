using ModInjector.Attributes;
using ModInjector.Modules;

namespace Sample.Core
{
    [DependsOn(
       //typeof(KernelModule)
    )]
    public class CoreModule : InjectorModule
    {

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(CoreModule).Assembly);
        }
    }
}
