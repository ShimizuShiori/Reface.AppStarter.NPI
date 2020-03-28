using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reface.AppStarter.Attributes;
using Reface.NPI.Generators;
using Dapper;

namespace Reface.AppStarter.NPI
{
    [Component]
    public class DapperSqlComandDescriptionExecutor : ISqlCommandDescriptionExecutor
    {
        public int Execute(DbConnectionContext dbConnectionContext, SqlCommandDescription sqlCommand)
        {
            throw new NotImplementedException();
        }

        public List<object> Select(DbConnectionContext dbConnectionContext, SqlCommandDescription sqlCommand, Type entityType)
        {
            throw new NotImplementedException();
        }
    }
}
