using Reface.AppStarter.Attributes;
using Reface.NPI;

namespace Reface.AppStarter.AppModules
{
    /// <summary>
    /// 依赖该模块，会向 IOC/DI 容器注入 <see cref="NpiDaoAttribute"/> 工作所需要的组件，但是该模块不会创建接口的动态实现。
    /// 如果你的模块中存在 <see cref="INpiDao{TEntity}"/> 并且希望对他们创建动态实现，你还需要添加对 <see cref="ProxyAppModule"/> 的依赖。
    /// </summary>
    /// <example>
    /// <![CDATA[
    ///     [NpiAppModule]
    ///     [ProxyAppModule]
    ///     public class MyAppModule : AppModule
    ///     {
    ///     }
    /// ]]>
    /// </example>
    [ComponentScanAppModule
        (
        IncludeNamespaces = new string[] 
        {
            "Reface.AppStarter.NPI.ExecuteResultHandlers",
            "Reface.AppStarter.NPI.SelectResultHandlers",
            "Reface.AppStarter.NPI.SqlCommandDescriptionExecutors"
        }
        )]
    public class NpiAppModule : AppModule
    {
    }
}
