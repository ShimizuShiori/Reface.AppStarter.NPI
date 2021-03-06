﻿using Reface.AppStarter.Attributes;
using System;
using System.Reflection;

namespace Reface.AppStarter.NPI.ExecuteResultHandlers
{
    /// <summary>
    /// <see cref="bool"/> 类型的执行结果处理器，
    /// 影响行数大于 0 就为 true。
    /// </summary>
    [Component]
    public class BooleanExecuteResultHandler : ISqlExecuteResultHandler
    {
        public bool CanHandle(MethodInfo method)
        {
            return method.ReturnType == typeof(Boolean);
        }

        public object Handle(MethodInfo method, int executeResult)
        {
            return executeResult > 0;
        }
    }
}
