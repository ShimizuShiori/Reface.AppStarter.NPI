using Reface.AppStarter.Attributes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace Reface.AppStarter.NPI.SelectResultHandlers
{
    /// <summary>
    /// 期望返回类型为 <see cref="IList{T}"/> 的处理器
    /// </summary>
    [Component]
    public class ListSelectResultHandler : ISqlSelectResultHandler
    {
        public bool CanHandle(MethodInfo method, Type entityType)
        {
            Type returnType = method.ReturnType;
            Type targetType = typeof(IList<>).MakeGenericType(new Type[] { entityType });
            if (returnType == targetType) return true;
            bool canHandle = returnType.GetInterface(targetType.FullName) != null;
            return canHandle;
        }

        public object Handle(MethodInfo method, Type entityType, IEnumerable<object> selectedResult)
        {
            Type type = typeof(List<>).MakeGenericType(new Type[] { entityType });
            object result = Activator.CreateInstance(type);
            IList list = (IList)selectedResult;
            foreach (var x in list)
                ((IList)result).Add(x);
            return result;
        }
    }
}
