using Reface.NPI.Generators;
using System;
using System.Collections.Generic;

namespace Reface.AppStarter.NPI
{
    public interface ISqlCommandDescriptionExecutor
    {
        int Execute(DbConnectionContext dbConnectionContext, SqlCommandDescription sqlCommand);

        List<object> Select(DbConnectionContext dbConnectionContext, SqlCommandDescription sqlCommand, Type entityType);
    }
}
