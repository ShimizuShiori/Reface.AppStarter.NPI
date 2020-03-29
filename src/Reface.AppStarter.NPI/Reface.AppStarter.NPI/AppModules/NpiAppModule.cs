using System.Collections.Generic;

namespace Reface.AppStarter.AppModules
{
    [ComponentScanAppModule]
    public class NpiAppModule : AppModule
    {
        public override void OnUsing(AppSetup setup, IAppModule targetModule)
        {
            var list = (this.DependentModules as IList<IAppModule>);
            if (list != null)
                list.Add(new ProxyAppModule(targetModule));
            base.OnUsing(setup, targetModule);
        }
    }
}
