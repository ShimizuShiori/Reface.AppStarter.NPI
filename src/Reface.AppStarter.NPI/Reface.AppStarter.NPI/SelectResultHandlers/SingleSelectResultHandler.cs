using Reface.AppStarter.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Reface.AppStarter.NPI.SelectResultHandlers
{
    [Component]
    public class SingleSelectResultHandler : ISqlSelectResultHandler
    {
        public bool CanHandle(MethodInfo method, Type entityType)
        {
            return method.ReturnType == entityType;
        }

        public object Handle(MethodInfo method, Type entityType, IEnumerable<object> selectedResult)
        {
            if (selectedResult.Any()) return selectedResult.FirstOrDefault();
            return null;
        }
    }
}
