using Reface.AppStarter.Attributes;
using System.Reflection;

namespace Reface.AppStarter.NPI.ExecuteResultHandlers
{
    /// <summary>
    /// 整形的执行结果处理器
    /// </summary>
    [Component]
    public class IntExecuteResultHandler : ISqlExecuteResultHandler
    {
        public bool CanHandle(MethodInfo method)
        {
            return method.ReturnType == typeof(int);
        }

        public object Handle(MethodInfo method, int executeResult)
        {
            return executeResult;
        }
    }
}
