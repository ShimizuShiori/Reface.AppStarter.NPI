using System;
using System.Collections.Generic;
using System.Reflection;
using Reface.NPI;

namespace Reface.AppStarter.NPI
{
    /// <summary>
    /// 对数据库查询的结果集的处理器
    /// </summary>
    public interface ISqlSelectResultHandler
    {
        /// <summary>
        /// 判断该处理器是否能够处理此结果集
        /// </summary>
        /// <param name="method">接口中的方法</param>
        /// <param name="entityType">期望返回的实体类型</param>
        /// <returns></returns>
        bool CanHandle(MethodInfo method, Type entityType);

        /// <summary>
        /// 处理结果集，并将结果转换为 <see cref="INpiDao{TEntity}"/> 接口中方法期望的结果类型
        /// </summary>
        /// <param name="method">接口中的方法</param>
        /// <param name="entityType">期望返回的实体类型</param>
        /// <param name="selectedResult">查询出的结果集</param>
        /// <returns></returns>
        object Handle(MethodInfo method, Type entityType, IEnumerable<object> selectedResult);
    }
}
