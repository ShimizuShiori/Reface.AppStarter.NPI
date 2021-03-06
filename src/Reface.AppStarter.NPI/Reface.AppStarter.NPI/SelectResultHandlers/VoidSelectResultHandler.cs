﻿using Reface.AppStarter.Attributes;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Reface.AppStarter.NPI.SelectResultHandlers
{
    /// <summary>
    /// 期望返回类型为 <see cref="void"/> 时的处理器
    /// </summary>
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
