using Reface.AppStarter.Attributes;
using Reface.AppStarter.NPI.SqlServer.Configs;
using System.Data.SqlClient;

namespace Reface.AppStarter.NPI.SqlServer
{
    [Component]
    public class SqlServerDbConnectionContextProvider : IDbConnectionContextProvider
    {
        private readonly SqServerConfig config;
        private DbConnectionContext dbConnectionContext;
        private readonly SqlConnection sqlConnection;

        public SqlServerDbConnectionContextProvider(SqServerConfig config)
        {
            this.config = config;
            this.sqlConnection = new SqlConnection(config.ConnectionString);
            this.dbConnectionContext = new DbConnectionContext(this.sqlConnection);
        }

        public void Dispose()
        {
            this.sqlConnection.Dispose();
        }

        public DbConnectionContext Provide()
        {
            return this.dbConnectionContext;
        }
    }
}
