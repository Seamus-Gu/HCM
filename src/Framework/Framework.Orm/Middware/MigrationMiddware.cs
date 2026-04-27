using Framework.Core;
using Microsoft.AspNetCore.Builder;

namespace Framework.Orm.Middware
{
    public static class MigrationMiddware
    {
        public static void UseMigrationMiddleware(this IApplicationBuilder app)
        {
            var dbConfig = App.GetConfig<DBConfig>(OrmConstant.DB_CONFIG);

            if (dbConfig.UseDBMigration)
            {

            }
        }
    }
}
