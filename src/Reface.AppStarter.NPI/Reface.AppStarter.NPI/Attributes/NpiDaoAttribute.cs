using Reface.AppStarter.Attributes;
using Reface.AppStarter.Proxy;
using System;

namespace Reface.AppStarter.NPI.Attributes
{
    [AttributeUsage(AttributeTargets.Interface)]
    public class NpiDaoAttribute : ProxyAttribute
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
