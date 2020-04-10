using Reface.AppStarter.Attributes;

namespace Reface.AppStarter.NPI.Test
{
    public class DbConnectionContextProvider : IDbConnectionContextProvider
    {
        private readonly DbConnectionContext dbConnectionContext;

        public DbConnectionContextProvider()
        {
            this.dbConnectionContext = new DbConnectionContext(new TestConnection());
        }

        public void Dispose()
        {
            DebugLogger.Info("DbConnectionContextProvider.Dispose");
        }

        public DbConnectionContext Provide()
        {
            return this.dbConnectionContext;
        }
    }
}
