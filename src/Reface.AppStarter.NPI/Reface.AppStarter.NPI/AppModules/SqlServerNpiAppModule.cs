using Reface.AppStarter.Attributes;
using Reface.AppStarter.NPI;
using Reface.AppStarter.NPI.SqlServer;
using Reface.AppStarter.NPI.SqlServer.Configs;

namespace Reface.AppStarter.AppModules
{
    [ComponentScanAppModule]
    [AutoConfigAppModule]
    public class SqlServerNpiAppModule : AppModule
    {
        [ConfigCreator("SqlServer")]
        public SqServerConfig GetSqServerConfig()
        {
            return new SqServerConfig();
        }

        [ComponentCreator]
        public IDbConnectionContextProvider GetDbConnectionContextProvider(SqServerConfig config)
        {
            return new SqlServerDbConnectionContextProvider(config);
        }
    }
}
