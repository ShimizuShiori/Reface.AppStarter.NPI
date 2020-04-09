using System.Data;

namespace Reface.AppStarter.NPI.Test
{
    public class TestDbTran : IDbTransaction
    {
        public IDbConnection Connection { get; set; }

        public IsolationLevel IsolationLevel { get; set; }

        public void Commit()
        {
            
        }

        public void Dispose()
        {
            
        }

        public void Rollback()
        {
            
        }
    }
}
