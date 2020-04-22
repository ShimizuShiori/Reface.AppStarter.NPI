using Reface.AppStarter.AppModules;
using Reface.AppStarter.Attributes;

namespace Reface.AppStarter.NPI.Test
{
    [ComponentScanAppModule]
    [NpiAppModule]
    [ProxyAppModule]
    public class TestAppModule2 : AppModule
    {
        [ComponentCreator]
        public IDbConnectionContextProvider GetDbConnectionContextProvider()
        {
            return new DbConnectionContextProvider2();
        }
    }
}
