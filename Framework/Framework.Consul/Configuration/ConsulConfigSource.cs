using Consul;
using Microsoft.Extensions.Configuration;

namespace Framework.Consul
{
    internal class ConsulConfigSource : IConfigurationSource
    {
        private readonly ConsulClient _consulClient;
        private readonly TimeSpan _timerCycle;
        private readonly string _assemblyName;
        private readonly string _env;

        public ConsulConfigSource(
            ConsulClient consulClient,
            TimeSpan timerCycle,
            string assemblyName,
            string env)
        {
            _consulClient = consulClient;
            _timerCycle = timerCycle;
            _assemblyName = assemblyName;
            _env = env;
        }

        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return new ConsulConfigurationProvider(
                _consulClient,
                _timerCycle,
                _assemblyName,
                _env);
        }
    }
}