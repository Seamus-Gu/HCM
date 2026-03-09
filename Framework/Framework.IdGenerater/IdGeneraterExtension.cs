using Framework.Core.Application;
using Framework.Core.Constants;
using Microsoft.Extensions.DependencyInjection;
using Yitter.IdGenerator;

namespace Framework.IdGenerater
{
    /// <summary>
    /// Provides extension methods for registering a distributed ID generator in the dependency injection container.
    /// </summary>
    /// <remarks>This class is intended to be used with dependency injection in ASP.NET Core or similar .NET
    /// applications. It configures and registers a distributed ID generator using application-specific settings. The
    /// generated IDs are suitable for use as unique identifiers across distributed systems.</remarks>
    public static class IdGeneraterExtension
    {
        /// <summary>
        /// Adds a distributed unique ID generator to the specified service collection using the configured options.
        /// </summary>
        /// <remarks>This method configures and registers a Snowflake-style ID generator for use in
        /// distributed systems. The generator options, such as worker ID and bit lengths, are loaded from application
        /// configuration. Ensure that each service instance uses a unique worker ID to avoid ID collisions across
        /// services.</remarks>
        /// <param name="services">The service collection to which the ID generator will be added. Cannot be null.</param>
        public static void AddIdGenerater(this IServiceCollection services)
        {
            var idConfig = App.GetConfig<IdConfig>(FrameworkConstant.SNOW_ID);
            // 创建 IdGeneratorOptions 对象，可在构造函数中输入 WorkerId： 微服务不同服务配置不同Id
            var options = new IdGeneratorOptions(58);
            // options.WorkerIdBitLength = 10; // 默认值6，限定 WorkerId 最大值为2^6-1，即默认最多支持64个节点。
            // options.SeqBitLength = 6; // 默认值6，限制每毫秒生成的ID个数。若生成速度超过5万个/秒，建议加大 SeqBitLength 到 10。
            // options.BaseTime = Your_Base_Time; // 如果要兼容老系统的雪花算法，此处应设置为老系统的BaseTime。
            // ...... 其它参数参考 IdGeneratorOptions 定义。

            // 保存参数（务必调用，否则参数设置不生效）：
            YitIdHelper.SetIdGenerator(options);
        }
    }
}