namespace Reface.AppStarter.AppModules
{
    /// <summary>
    /// 该模块会将与 SqlServer 有关的组件和配置类注入到 IOC / DI 容器中
    /// </summary>
    [ComponentScanAppModule
        (
            IncludeNamespaces = new string[]
            {
                "Reface.AppStarter.NPI.SqlServer"
            }
        )]
    [AutoConfigAppModule
        (
            IncludeNamespaces = new string[] 
            {
                "Reface.AppStarter.NPI.SqlServer"
            }
        )]
    public class SqlServerNpiAppModule : AppModule
    {
    }
}
