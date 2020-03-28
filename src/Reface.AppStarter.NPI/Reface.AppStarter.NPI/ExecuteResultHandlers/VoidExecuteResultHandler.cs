using Reface.AppStarter.Attributes;
using System.Reflection;

namespace Reface.AppStarter.NPI.ExecuteResultHandlers
{
    [Component]
    public class VoidExecuteResultHandler : ISqlExecuteResultHandler
    {
        public bool CanHandle(MethodInfo method)
        {
            return method.ReturnType == typeof(void);
        }

        public object Handle(MethodInfo method, int executeResult)
        {
            return null;
        }
    }
}
