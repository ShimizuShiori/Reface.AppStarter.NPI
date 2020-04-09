using Reface.AppStarter.Attributes;

namespace Reface.AppStarter.NPI.Test
{
    [Component]
    public class DbConnectionContextProvider : IDbConnectionContextProvider
    {
        private readonly DbConnectionContext dbConnectionContext;

        public DbConnectionContextProvider()
        {
            this.dbConnectionContext = new DbConnectionContext(new TestConnection());
        }

        public DbConnectionContext Provide()
        {
            return this.dbConnectionContext;
        }
    }
}
