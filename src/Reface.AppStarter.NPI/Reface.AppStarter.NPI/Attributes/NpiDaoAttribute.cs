using Reface.AppStarter.NPI;
using Reface.AppStarter.NPI.Errors;
using Reface.AppStarter.NPI.Events;
using Reface.AppStarter.Proxy;
using Reface.EventBus;
using Reface.NPI;
using Reface.NPI.Generators;
using System;
using System.Collections.Generic;

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

            ISqlCommandGenerator g = NpiServicesCollection.GetService<ISqlServerCommandGenerator>();
            SqlCommandDescription d = g.Generate(info.Method, info.Arguments);
            this.EventBus.Publish(new SqlCommandDescriptionGeneratedEvent(this, d));

            if (info.Method.ReturnType == typeof(void))
                d.Mode = SqlCommandExecuteModes.Execute;

            switch (d.Mode)
            {
                case SqlCommandExecuteModes.Execute:
                    int i = this.Executor.Execute(this.Provider.Provide(), d);
                    foreach (var handler in this.ExecuteResultHandlers)
                    {
                        if (!handler.CanHandle(info.Method)) continue;
                        info.ReturnValue = handler.Handle(info.Method, i);
                    }
                    break;
                case SqlCommandExecuteModes.Query:
                    {
                        Type returnType = info.Method.ReturnType;
                        Type itemType;
                        if (TryGetIEnumerableItemType(returnType, out itemType))
                        {
                            returnType = itemType;
                        }

                        IEnumerable<object> list = this.Executor.Select(this.Provider.Provide(), d, returnType);
                        foreach (var handler in this.SelectResultHandlers)
                        {
                            if (!handler.CanHandle(info.Method, returnType)) continue;
                            info.ReturnValue = handler.Handle(info.Method, returnType, list);
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        private bool TryGetIEnumerableItemType(Type type, out Type itemType)
        {
            itemType = null;
            if (type == typeof(IEnumerable<>))
            {
                itemType = type.GetGenericArguments()[0];
                return true;
            }
            var infType = type.GetInterface(typeof(IEnumerable<>).FullName);
            if (infType == null) return false;

            itemType = infType.GetGenericArguments()[0];
            return true;
        }
    }
}
