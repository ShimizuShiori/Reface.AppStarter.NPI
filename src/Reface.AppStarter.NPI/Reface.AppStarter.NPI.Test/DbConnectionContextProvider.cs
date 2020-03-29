using Reface.AppStarter.Attributes;

namespace Reface.AppStarter.NPI.Test
{
    [Component]
    public class DbConnectionContextProvider : IDbConnectionContextProvider
    {
        public DbConnectionContext Provide()
        {
            return new DbConnectionContext(null);
        }
    }
}
