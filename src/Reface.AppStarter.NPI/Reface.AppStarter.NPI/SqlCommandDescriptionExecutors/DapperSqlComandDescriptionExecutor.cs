using Dapper;
using Reface.AppStarter.Attributes;
using Reface.NPI.Generators;
using System;
using System.Collections.Generic;

namespace Reface.AppStarter.NPI.SqlCommandDescriptionExecutors
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
