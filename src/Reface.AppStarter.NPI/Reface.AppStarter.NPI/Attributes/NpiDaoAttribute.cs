using Reface.AppStarter.NPI;
using Reface.AppStarter.NPI.Errors;
using Reface.AppStarter.NPI.Events;
using Reface.AppStarter.Proxy;
using Reface.EventBus;
using Reface.NPI;
using Reface.NPI.Generators;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Reface.AppStarter.Attributes
{
    [AttributeUsage(AttributeTargets.Interface)]
    public class NpiDaoAttribute : ImplementorAttribute
    {
        public ISqlCommandDescriptionExecutor Executor { get; set; }
        public IDbConnectionContextProvider Provider { get; set; }
        public IEnumerable<ISqlSelectResultHandler> SelectResultHandlers { get; set; }
        public IEnumerable<ISqlExecuteResultHandler> ExecuteResultHandlers { get; set; }

        public IEventBus EventBus { get; set; }

        private void AssertProviderIsValid()
        {
            var context_1 = this.Provider.Provide();
            var context_2 = this.Provider.Provide();
            if (context_1 == context_2) return;
            throw new MustProvideSingletoneInstanceException(this.Provider.GetType());
        }

        public override void Intercept(InterfaceInvocationInfo info)
        {
            this.AssertProviderIsValid();
            Type typeOfIDao = typeof(INpiDao<>);
            Type entityType = info.Method.DeclaringType.GetInterface(typeOfIDao.FullName).GetGenericArguments()[0];

            ISqlCommandGenerator g = NpiServicesCollection.GetService<ISqlServerCommandGenerator>();
            SqlCommandDescription d = g.Generate(info.Method, info.Arguments);
            this.EventBus.Publish(new SqlCommandDescriptionGeneratedEvent(this, d));
            switch (d.Type)
            {
                case SqlCommandTypes.Insert:
                case SqlCommandTypes.Update:
                case SqlCommandTypes.Delete:
                    int i = this.Executor.Execute(this.Provider.Provide(), d);
                    foreach (var handler in this.ExecuteResultHandlers)
                    {
                        if (!handler.CanHandle(info.Method)) continue;
                        info.ReturnValue = handler.Handle(info.Method, i);
                    }
                    break;
                case SqlCommandTypes.Select:
                    {
                        IEnumerable<object> list = this.Executor.Select(this.Provider.Provide(), d, entityType);
                        foreach (var handler in this.SelectResultHandlers)
                        {
                            if (!handler.CanHandle(info.Method, entityType)) continue;
                            info.ReturnValue = handler.Handle(info.Method, entityType, list);
                        }
                    }
                    break;
                case SqlCommandTypes.Count:
                    {
                        IEnumerable<object> list = this.Executor.Select(this.Provider.Provide(), d, typeof(long));
                        info.ReturnValue = Convert.ChangeType(list.FirstOrDefault(), info.Method.ReturnType);
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
