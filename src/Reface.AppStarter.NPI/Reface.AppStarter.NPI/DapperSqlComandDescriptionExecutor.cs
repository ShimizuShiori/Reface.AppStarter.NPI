using Reface.AppStarter.Attributes;
using Reface.NPI.Generators;
using System;
using System.Collections.Generic;
using Dapper;

namespace Reface.AppStarter.NPI
{
    [Component]
    public class DapperSqlComandDescriptionExecutor : ISqlCommandDescriptionExecutor
    {
        public int Execute(DbConnectionContext dbConnectionContext, SqlCommandDescription sqlCommand)
        {
            DapperParameters parameters = new DapperParameters(sqlCommand);
            return dbConnectionContext.DbConnection
                .Execute(sqlCommand.SqlCommand, parameters, transaction: dbConnectionContext.DbTransaction);
        }

        public IEnumerable<object> Select(DbConnectionContext dbConnectionContext, SqlCommandDescription sqlCommand, Type entityType)
        {
            DapperParameters parameters = new DapperParameters(sqlCommand);
            return dbConnectionContext.DbConnection
                .Query(entityType, sqlCommand.SqlCommand, parameters, transaction: dbConnectionContext.DbTransaction);
        }
    }
}
