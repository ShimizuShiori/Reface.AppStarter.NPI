using System;
using System.Reflection;

namespace Reface.AppStarter.NPI.ExecuteResultHandlers
{
    public class BooleanExecuteResultHandler : ISqlExecuteResultHandler
    {
        public bool CanHandle(MethodInfo method, int executeResult)
        {
            return method.ReturnType == typeof(Boolean);
        }

        public object Handle(MethodInfo method, int executeResult)
        {
            return executeResult > 0;
        }
    }
}
