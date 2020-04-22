using Reface.AppStarter.AppModules;

namespace Reface.AppStarter.NPI.Test
{
    [ComponentScanAppModule]
    [NpiAppModule]
    [SqlServerNpiAppModule]
    public class TestSqlServerAppModule : AppModule
    {
    }
}
