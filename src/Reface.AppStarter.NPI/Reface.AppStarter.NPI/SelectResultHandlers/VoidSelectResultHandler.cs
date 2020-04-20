using Reface.AppStarter.Attributes;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Reface.AppStarter.NPI.SelectResultHandlers
{
    [Component]
    public class VoidSelectResultHandler : ISqlSelectResultHandler
    {
        public bool CanHandle(MethodInfo method, Type entityType)
        {
            return method.ReturnType == typeof(void);
        }

        public object Handle(MethodInfo method, Type entityType, IEnumerable<object> selectedResult)
        {
            return null;
        }
    }
}
