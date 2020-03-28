using Reface.NPI.Generators;
using System.Collections.Generic;
using System.Data;
using static Dapper.SqlMapper;

namespace Reface.AppStarter.NPI
{
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
