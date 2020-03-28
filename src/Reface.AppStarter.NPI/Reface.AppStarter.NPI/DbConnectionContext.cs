using System;
using System.Data;

namespace Reface.AppStarter.NPI
{
    public class DbConnectionContext
    {
        public Guid Id { get; private set; }
        public IDbConnection DbConnection { get; private set; }
        public IDbTransaction DbTransaction { get; private set; }

        public DbConnectionContext(IDbConnection dbConnection)
        {
            DbConnection = dbConnection;
            this.Id = Guid.NewGuid();
            Console.WriteLine($"{nameof(DbConnectionContext)}.Ctor : Id = {Id}");
        }

        public void BeginTran()
        {
            this.DbTransaction = this.DbConnection.BeginTransaction();
        }

        public void RollbackTran()
        {
            this.DbTransaction.Rollback();
            this.DbTransaction.Dispose();
            this.DbTransaction = null;
        }

        public void CommitTran()
        {
            this.DbTransaction.Commit();
            this.DbTransaction.Dispose();
            this.DbTransaction = null;
        }
    }
}
