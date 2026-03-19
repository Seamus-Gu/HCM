using Consul;
using Seed.Framework.Core;

namespace Seed.Framework.Consul
{
    internal static class KVPairExtension
    {
        internal static IDictionary<string, string> ToConfigDIc(this KVPair result)
        {
            var stream = new MemoryStream(result.Value);

            return JsonToDictionatyUtil.Parse(stream);
        }
    }
}