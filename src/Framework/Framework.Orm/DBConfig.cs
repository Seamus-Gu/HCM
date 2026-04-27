using SqlSugar;

namespace Framework.Orm
{
    /// <summary>
    /// Represents the configuration settings for database connections and migration options.
    /// </summary>
    public class DBConfig
    {
        /// <summary>
        /// Gets or sets the collection of connection configuration settings.
        /// </summary>
        /// <remarks>Each item in the collection represents a distinct connection configuration. Modifying
        /// this list affects the available connection options.</remarks>
        public List<ConnectionConfig> ConnectionConfigs { get; set; } = new();

        /// <summary>
        /// Gets or sets a value indicating whether database migration should be performed during application startup.
        /// </summary>
        public bool UseDBMigration { get; set; } = true;
    }
}