using System;

namespace Reface.AppStarter.NPI
{
    /// <summary>
    /// 数据库连接上下文提供器。
    /// Reface.AppStarter.NPI 内部不实现此接口，
    /// 面向具体数据库的库应当实现此接口。
    /// </summary>
    public interface IDbConnectionContextProvider : IDisposable
    {
        /// <summary>
        /// 提供一个数据库连接上下文。
        /// 注意：对于同一个 <see cref="IDbConnectionContextProvider"/> 实例，
        /// 应当提供同一个 <see cref="DbConnectionContext"/> 实例。
        /// </summary>
        /// <returns></returns>
        DbConnectionContext Provide();
    }
}
