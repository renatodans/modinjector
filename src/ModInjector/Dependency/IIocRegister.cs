using System.Reflection;

namespace ModInjector.Dependency
{
    public interface IIocRegister
    {
        void RegisterAssemblyByConvention(Assembly assembly);
    }
}
