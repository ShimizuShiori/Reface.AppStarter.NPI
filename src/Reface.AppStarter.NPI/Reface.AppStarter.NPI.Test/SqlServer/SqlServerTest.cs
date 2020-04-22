using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reface.AppStarter.Attributes;
using Reface.AppStarter.NPI.SqlServer.Configs;
using Reface.AppStarter.UnitTests;

namespace Reface.AppStarter.NPI.Test.SqlServer
{
    [TestClass]
    public class SqlServerTest : TestClassBase<TestSqlServerAppModule>
    {
        [AutoCreate]
        public SqServerConfig Config { get; set; }

        [AutoCreate]
        public IDbConnectionContextProvider DbConnectionContextProvider { get; set; }

        [TestMethod]
        public void HasConfig()
        {
            Assert.IsNotNull(Config);
        }

        [TestMethod]
        public void HasProvider()
        {

        }
    }
}
