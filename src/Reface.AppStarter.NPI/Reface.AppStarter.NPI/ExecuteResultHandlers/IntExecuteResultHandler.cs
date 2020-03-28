using System.Reflection;

namespace Reface.AppStarter.NPI.ExecuteResultHandlers
{
    public class IntExecuteResultHandler : ISqlExecuteResultHandler
    {
        public bool CanHandle(MethodInfo method, int executeResult)
        {
            return method.ReturnType == typeof(int);
        }

        public object Handle(MethodInfo method, int executeResult)
        {
            return executeResult;
        }
    }
}
