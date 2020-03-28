using Reface.AppStarter.NPI;
using Reface.AppStarter.Proxy;
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

        public override void Intercept(InterfaceInvocationInfo info)
        {
            Type typeOfIDao = typeof(INpiDao<>);
            Type entityType = info.Method.DeclaringType.GetInterface(typeOfIDao.FullName).GetGenericArguments()[0];

            ISqlCommandGenerator g = NpiServicesCollection.GetService<ISqlServerCommandGenerator>();
            SqlCommandDescription d = g.Generate(info.Method, info.Arguments);

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
                    List<object> list = this.Executor.Select(this.Provider.Provide(), d, entityType);
                    foreach (var handler in this.SelectResultHandlers)
                    {
                        if (!handler.CanHandle(info.Method, entityType)) continue;
                        info.ReturnValue = handler.Handle(info.Method, entityType, list);
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
