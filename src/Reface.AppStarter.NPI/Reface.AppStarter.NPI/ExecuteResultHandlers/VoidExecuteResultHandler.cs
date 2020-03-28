using System.Reflection;

namespace Reface.AppStarter.NPI.ExecuteResultHandlers
{
    public class VoidExecuteResultHandler : ISqlExecuteResultHandler
    {
        public bool CanHandle(MethodInfo method, int executeResult)
        {
            return method.ReturnType == typeof(void);
        }

        public object Handle(MethodInfo method, int executeResult)
        {
            return null;
        }
    }
}
