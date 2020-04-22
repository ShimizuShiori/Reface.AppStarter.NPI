using Reface.NPI.Generators;
using System;
using System.Collections.Generic;

namespace Reface.AppStarter.NPI
{
    /// <summary>
    /// <see cref="SqlCommandDescription"/> 的执行器，
    /// 将 NPI 生成的数据库执行信息执行到数据库上的组件。
    /// </summary>
    public interface ISqlCommandDescriptionExecutor
    {
        /// <summary>
        /// 执行并返回影响的行数
        /// </summary>
        /// <param name="dbConnectionContext"></param>
        /// <param name="sqlCommand"></param>
        /// <returns></returns>
        int Execute(DbConnectionContext dbConnectionContext, SqlCommandDescription sqlCommand);

        /// <summary>
        /// 查询并返回查询的列表
        /// </summary>
        /// <param name="dbConnectionContext"></param>
        /// <param name="sqlCommand"></param>
        /// <param name="entityType">期望的实体类型，即 <see cref="IEnumerable{T}"/> 中每一个元素的类型</param>
        /// <returns></returns>
        IEnumerable<object> Select(DbConnectionContext dbConnectionContext, SqlCommandDescription sqlCommand, Type entityType);
    }
}
