using Reface.AppStarter.Attributes;
using Reface.AppStarter.Proxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reface.AppStarter.NPI.Test.Attributes
{
    public class AProxy : ProxyAttribute
    {
        public override void OnExecuted(ExecutedInfo executedInfo)
        {
        }

        public override void OnExecuteError(ExecuteErrorInfo executeErrorInfo)
        {
        }

        public override void OnExecuting(ExecutingInfo executingInfo)
        {
        }
    }
}
