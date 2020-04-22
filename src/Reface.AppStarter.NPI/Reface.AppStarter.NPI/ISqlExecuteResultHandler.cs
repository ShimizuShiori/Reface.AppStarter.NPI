using System.Reflection;

namespace Reface.AppStarter.NPI
{
    /// <summary>
    /// 对数据库执行结果的处理器
    /// </summary>
    public interface ISqlExecuteResultHandler
    {
        /// <summary>
        /// 返回是否能够处理此结果
        /// </summary>
        /// <param name="method">执行的接口方法</param>
        /// <returns></returns>
        bool CanHandle(MethodInfo method);

        /// <summary>
        /// 处理结果，并返回符合接口预期的类型
        /// </summary>
        /// <param name="method">执行的接口方法</param>
        /// <param name="executeResult">数据库返回的处理结果</param>
        /// <returns></returns>
        object Handle(MethodInfo method, int executeResult);
    }
}
