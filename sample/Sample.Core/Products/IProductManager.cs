using ModInjector.Dependency.IoC;
using System.Collections.Generic;

namespace Sample.Core.Products
{
    public interface IProductManager : ITransientDependency
    {
        List<Product> GetAll();        
    }
}
