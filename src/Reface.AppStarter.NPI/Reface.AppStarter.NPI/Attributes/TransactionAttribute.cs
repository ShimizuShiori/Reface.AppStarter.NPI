using Reface.AppStarter.Attributes;
using Reface.AppStarter.Proxy;
using System;

namespace Reface.AppStarter.NPI.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class TransactionAttribute : ProxyAttribute
    {
        public IDbConnectionContextProvider DbConnectionContextProvider { get; set; }


        public override void OnExecuted(ExecutedInfo executedInfo)
        {
            this.DbConnectionContextProvider.Provide().CommitTran();            
        }

        public override void OnExecuteError(ExecuteErrorInfo executeErrorInfo)
        {
            this.DbConnectionContextProvider.Provide().RollbackTran();
        }

        public override void OnExecuting(ExecutingInfo executingInfo)
        {
            this.DbConnectionContextProvider.Provide().BeginTran();
        }
    }
}
