using Reface.AppStarter.Attributes;

namespace Reface.AppStarter.NPI.SqlServer.Configs
{
    [Config("SqlServer")]
    public class SqServerConfig
    {
        public string ConnectionString { get; set; }
    }
}
