using Reface.AppStarter.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Reface.AppStarter.NPI.SelectResultHandlers
{
    [Component]
    public class FirstRowFirstCellSelectResultHandler : ISqlSelectResultHandler
    {
        private readonly static Type[] baseTypes = new Type[]
        {
            typeof(int),
            typeof(long),
            typeof(float),
            typeof(double),
            typeof(string),
            typeof(bool),
            typeof(Guid),
            typeof(DateTime)
        };

        public bool CanHandle(MethodInfo method, Type entityType)
        {
            foreach (Type numberType in baseTypes)
            {
                if (method.ReturnType == numberType) return true;
            }
            return false;
        }

        public object Handle(MethodInfo method, Type entityType, IEnumerable<object> selectedResult)
        {
            return selectedResult.FirstOrDefault();
        }
    }
}
