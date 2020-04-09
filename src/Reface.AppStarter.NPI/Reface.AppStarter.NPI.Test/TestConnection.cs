using System.Data;

namespace Reface.AppStarter.NPI.Test
{
    public class TestConnection : IDbConnection
    {
        public string ConnectionString { get; set; }

        public int ConnectionTimeout { get; set; }

        public string Database { get; set; }

        public ConnectionState State { get; set; } = ConnectionState.Closed;

        public IDbTransaction BeginTransaction()
        {
            return new TestDbTran();
        }

        public IDbTransaction BeginTransaction(IsolationLevel il)
        {
            return new TestDbTran();
        }

        public void ChangeDatabase(string databaseName)
        {
        }

        public void Close()
        {
            this.State = ConnectionState.Closed;
        }

        public IDbCommand CreateCommand()
        {
            return null;
        }

        public void Dispose()
        {
        }

        public void Open()
        {
            this.State = ConnectionState.Open;
        }
    }
}
