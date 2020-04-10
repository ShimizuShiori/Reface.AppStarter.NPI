using System;

namespace Reface.AppStarter.NPI.Errors
{
    public class MustProvideSingletoneInstanceException : Exception
    {
        public Type DbConnectionContextProviderType { get; private set; }

        public MustProvideSingletoneInstanceException(Type dbConnectionContextProviderType)
            :base($"DbConnectionContextProvider.Provide() 方法应当提供同实例的数据库连接上下文，但是 {dbConnectionContextProviderType} 提供了不同的实例")
        {
            DbConnectionContextProviderType = dbConnectionContextProviderType;
        }
    }
}
