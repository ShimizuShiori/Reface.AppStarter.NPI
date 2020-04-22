using System;
using System.Data;
using Reface.AppStarter.NPI.Attributes;

namespace Reface.AppStarter.NPI
{
    /// <summary>
    /// 数据库连接上下文
    /// </summary>
    public class DbConnectionContext
    {
        /// <summary>
        /// 唯一标识
        /// </summary>
        public Guid Id { get; private set; }


        /// <summary>
        /// 数据库连接
        /// </summary>
        public IDbConnection DbConnection { get; private set; }

        /// <summary>
        /// 数据库事务
        /// </summary>
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

        /// <summary>
        /// 开启事务。
        /// 由于 <see cref="TransactionAttribute"/> 会存在事务嵌套的问题，
        /// 对于同一个 <see cref="DbConnectionContext"/> 实例，当事务已经开启，再使用此方法将不会再次开启事务。
        /// </summary>
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

        /// <summary>
        /// 回滚事务。
        /// 由于 <see cref="TransactionAttribute"/> 会存在事务嵌套的问题，
        /// 对于是调用了多次的 <see cref="BeginTran"/> 的 <see cref="DbConnectionContext"/> 实例，第一次回滚的调用，就会对所有任务进行回滚。
        /// 设计意图是，当遇到一个异常时，就回滚所有事务。
        /// </summary>
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

        /// <summary>
        /// 提交事务。
        /// 由于 <see cref="TransactionAttribute"/> 会存在事务嵌套的问题，
        /// 因此对于执行了多次 <see cref="BeginTran"/> 的 <see cref="DbConnectionContext"/> 实例，只有第一次开启事务所对应的提交事务，才会真正的提交事务。
        /// </summary>
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
