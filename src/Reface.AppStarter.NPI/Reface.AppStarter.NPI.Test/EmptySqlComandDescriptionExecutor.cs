using Reface.NPI.Generators;
using System;
using System.Collections.Generic;

namespace Reface.AppStarter.NPI.Test
{
    public class EmptySqlComandDescriptionExecutor : ISqlCommandDescriptionExecutor
    {
        public int Execute(DbConnectionContext dbConnectionContext, SqlCommandDescription sqlCommand)
        {
            Console.WriteLine(sqlCommand.ToString());
            return 10;
        }

        public IEnumerable<object> Select(DbConnectionContext dbConnectionContext, SqlCommandDescription sqlCommand, Type entityType)
        {
            if (sqlCommand.SqlCommand.Contains("COUNT"))
                return new List<object>() { 100 };


            return new List<object>() { Activator.CreateInstance(entityType), Activator.CreateInstance(entityType) };
        }
    }
}
