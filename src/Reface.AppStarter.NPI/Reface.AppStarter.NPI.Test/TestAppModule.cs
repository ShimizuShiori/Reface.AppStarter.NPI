using Reface.AppStarter.AppModules;
using Reface.AppStarter.Attributes;

namespace Reface.AppStarter.NPI.Test
{
    [ComponentScanAppModule]
    [NpiAppModule]
    [ProxyAppModule]
    public class TestAppModule : AppModule
    {
        [ReplaceCreator]
        public ISqlCommandDescriptionExecutor GetSqlCommandDescriptionExecutor()
        {
            return new EmptySqlComandDescriptionExecutor();
        }

        [ComponentCreator]
        public IDbConnectionContextProvider GetDbConnectionContextProvider()
        {
            return new DbConnectionContextProvider();
        }
    }
}
