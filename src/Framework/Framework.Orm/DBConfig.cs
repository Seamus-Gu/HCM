using SqlSugar;

namespace Framework.Orm
{
    public class DBConfig
    {
        public List<ConnectionConfig> ConnectionConfigs { get; set; } = new();
    }
}