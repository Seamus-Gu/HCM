using Consul;
using Framework.Core;

namespace Framework.Consul
{
    public class ServiceDiscover : IServiceDiscovery
    {
        private readonly IConsulClient _consul;  // 依赖官方的 ConsulClient

        public ServiceDiscover(IConsulClient consul) => _consul = consul;

        public async Task<Dictionary<string, string>> GetServices()
        {
            var services = await _consul.Agent.Services();
            var result = services.Response.ToDictionary(t => t.Value.Service, t => t.Key);

            return result;
        }
    }
}