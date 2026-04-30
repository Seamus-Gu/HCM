using Consul;
using Ocelot.Logging;
using Ocelot.Provider.Consul;
using Ocelot.Provider.Consul.Interfaces;

namespace HCM.Gateway.Middleware
{
    /// <summary>
    /// 自定义 Consul 服务构建器，用于根据特定需求扩展默认的 Consul 服务发现行为。
    /// </summary>
    /// <remarks>继承自 DefaultConsulServiceBuilder，可通过重写方法自定义下游主机的选择逻辑。适用于需要自定义服务注册或发现策略的场景。</remarks>
    public class CustomConsulServiceBuilder : DefaultConsulServiceBuilder
    {
        public CustomConsulServiceBuilder(
            IHttpContextAccessor contextAccessor,
            IConsulClientFactory clientFactory,
            IOcelotLoggerFactory loggerFactory) : base(contextAccessor, clientFactory, loggerFactory)
        {
        }

        protected override string GetDownstreamHost(ServiceEntry entry, Node node)
        {
            return entry.Service.Address;
        }
    }
}
