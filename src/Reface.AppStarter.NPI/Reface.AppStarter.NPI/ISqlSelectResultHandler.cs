using System;
using System.Collections.Generic;
using System.Reflection;

namespace Reface.AppStarter.NPI
{
    public interface ISqlSelectResultHandler
    {
        bool CanHandle(MethodInfo method, Type entityType);
        object Handle(MethodInfo method, Type entityType, IEnumerable<object> selectedResult);
    }
}
