using System;
using System.Data;

namespace Reface.AppStarter.NPI
{
    public class DbConnectionContext
    {
        public Guid Id { get; private set; }
        public IDbConnection DbConnection { get; private set; }
        public IDbTransaction DbTransaction { get; private set; }

        /// <summary>
        /// 嵌套的深度
        /// </summary>
        private int deep = 0;

        public DbConnectionContext(IDbConnection dbConnection)
        {
            DbConnection = dbConnection;
            this.Id = Guid.NewGuid();
            DebugLogger.Debug($"{nameof(DbConnectionContext)}.Ctor : Id = {Id}");
        }

        public void BeginTran()
        {
            if (++deep == 1)
            {
                if (this.DbConnection.State != ConnectionState.Open)
                    this.DbConnection.Open();
                DebugLogger.Info($"BeginTran Deep = {deep} , Id = {Id} ");
                this.DbTransaction = this.DbConnection.BeginTransaction();
                return;
            }

            DebugLogger.Warning($"SkipBeginTran Deep = {deep} , Id = {Id}");
        }

        public void RollbackTran()
        {
            if (this.DbTransaction == null)
            {
                DebugLogger.Warning($"SkipRollbackTran Tran is null");
                return;
            }
            deep = 0;
            DebugLogger.Info($"RollbackTran Deep = {deep} , Id = {Id} ");
            this.DbTransaction.Rollback();
            this.DbTransaction.Dispose();
            this.DbTransaction = null;
        }

        public void CommitTran()
        {
            if (this.DbTransaction == null)
            {
                DebugLogger.Warning($"SkipCommitTran Tran is null");
                return;
            }
            if (deep-- != 1)
            {
                DebugLogger.Warning($"SkipCommitTran Deep =  {deep} , Id = {Id}");
                return;
            }
            DebugLogger.Info($"CommitTran Deep = {deep} , Id = {Id} ");
            this.DbTransaction.Commit();
            this.DbTransaction.Dispose();
            this.DbTransaction = null;
        }
    }
}
