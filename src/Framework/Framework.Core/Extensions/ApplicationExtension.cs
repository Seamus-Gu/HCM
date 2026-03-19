using Microsoft.AspNetCore.Builder;

namespace Framework.Core
{
    public static class ApplicationExtension
    {
        /// <summary>
        /// 从 WebApplicationBuilder 初始化内部 App 对象
        /// </summary>
        /// <param name="builder"></param>
        public static void InitializeApp(this WebApplicationBuilder builder)
        {
            InternalApp.InitializeFromBuilder(builder);
        }

        /// <summary>
        /// 配置内部App
        /// </summary>
        /// <param name="builder"></param>
        public static void ConfigureApp(this IApplicationBuilder builder)
        {
            InternalApp.ConfigureInternalApp(builder);
        }
    }
}
