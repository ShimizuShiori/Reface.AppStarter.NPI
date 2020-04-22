using Reface.AppStarter.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Reface.AppStarter.NPI.SelectResultHandlers
{
    /// <summary>
    /// 期望返回类型为单一实体时的处理器
    /// </summary>
    [Component]
    public class SingleSelectResultHandler : ISqlSelectResultHandler
    {
        public bool CanHandle(MethodInfo method, Type entityType)
        {
            return method.ReturnType == entityType;
        }

        public object Handle(MethodInfo method, Type entityType, IEnumerable<object> selectedResult)
        {
            if (selectedResult.Any())
                return Convert.ChangeType(selectedResult.FirstOrDefault(), entityType);
            return null;
        }
    }
}
