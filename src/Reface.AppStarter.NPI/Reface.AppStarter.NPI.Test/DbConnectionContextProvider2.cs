using Reface.AppStarter.Attributes;

namespace Reface.AppStarter.NPI.Test
{
    public class DbConnectionContextProvider2 : IDbConnectionContextProvider
    {
        public DbConnectionContextProvider2()
        {
        }

        public DbConnectionContext Provide()
        {
            return new DbConnectionContext(new TestConnection());
        }
        public void Dispose()
        {
            DebugLogger.Info("DbConnectionContextProvider2.Dispose");
        }
    }
}
