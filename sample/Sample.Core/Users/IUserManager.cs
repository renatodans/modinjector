using ModInjector.Dependency.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Core.Users
{
    public interface IUserManager : ITransientDependency
    {
        string CurrentUser();
    }
}
