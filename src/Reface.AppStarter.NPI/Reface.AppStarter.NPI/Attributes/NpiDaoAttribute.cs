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
                    int i = this.Executor.Execute(null, d);
                    break;
                case SqlCommandTypes.Select:
                    List<object> list = this.Executor.Select(null, d, entityType);
                    break;
                default:
                    break;
            }
        }
    }
}
