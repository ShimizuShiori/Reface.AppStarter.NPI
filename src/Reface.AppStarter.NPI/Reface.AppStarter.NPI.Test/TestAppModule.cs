using Reface.AppStarter.AppModules;
using Reface.AppStarter.Attributes;

namespace Reface.AppStarter.NPI.Test
{
    [ComponentScanAppModule]
    [NpiAppModule]
    public class TestAppModule : AppModule
    {
        [ReplaceCreator]
        public ISqlCommandDescriptionExecutor GetSqlCommandDescriptionExecutor()
        {
            return new EmptySqlComandDescriptionExecutor();
        }
    }
}
