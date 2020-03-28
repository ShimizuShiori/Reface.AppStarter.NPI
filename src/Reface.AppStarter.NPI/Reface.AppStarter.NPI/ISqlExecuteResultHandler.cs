using System.Collections.Generic;
using System.Reflection;

namespace Reface.AppStarter.NPI
{
    public interface ISqlExecuteResultHandler
    {
        bool CanHandle(MethodInfo method);
        object Handle(MethodInfo method, int executeResult);
    }
}
