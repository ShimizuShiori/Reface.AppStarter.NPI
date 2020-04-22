using Reface.NPI.Generators;
using System.Collections.Generic;
using System.Data;
using static Dapper.SqlMapper;

namespace Reface.AppStarter.NPI
{
    /// <summary>
    /// Dapper 有着自己的参数转换方式，
    /// 该类负责将 <see cref="SqlCommandDescription"/> 转换为 Dapper 所需要的参数格式。
    /// </summary>
    public class DapperParameters : Dictionary<string, object>, IDynamicParameters
    {
        public DapperParameters(SqlCommandDescription description)
        {
            foreach (var p in description.Parameters)
            {
                this[p.Key] = p.Value.Value;
            }
        }
        public void AddParameters(IDbCommand command, Identity identity)
        {
            foreach (var pair in this)
            {
                var cp = command.CreateParameter();
                cp.ParameterName = pair.Key;
                cp.Value = pair.Value;
                command.Parameters.Add(cp);
            }
        }
    }
}
