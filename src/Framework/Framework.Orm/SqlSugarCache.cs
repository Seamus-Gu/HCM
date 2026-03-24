using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using SqlSugar;

namespace Framework.Orm;

/// <summary>
/// SqlSugar二级缓存
/// </summary>
public class SqlSugarCache : ICacheService
{
    private readonly IMemoryCache _cache;
    private readonly List<string> _keys;

    public SqlSugarCache()
    {
        _cache = new MemoryCache(new MemoryCacheOptions());
        _keys = new List<string>();
    }

    public void Add<V>(string key, V value)
    {
        _keys.Add(key);
        _cache.Set(key, value);
    }

    public void Add<V>(string key, V value, int cacheDurationInSeconds)
    {
        _keys.Add(key);
        _cache.Set(key, value, TimeSpan.FromSeconds(cacheDurationInSeconds));
    }

    public bool ContainsKey<V>(string key)
    {
        return _cache.TryGetValue<V>(key, out _);
    }

    public V Get<V>(string key)
    {
        return _cache.Get<V>(key);
    }

    public IEnumerable<string> GetAllKey<V>()
    {
        return _keys.ToList();
    }

    public V GetOrCreate<V>(string cacheKey, Func<V> create, int cacheDurationInSeconds = int.MaxValue)
    {
        if (!_cache.TryGetValue(cacheKey, out V value))
        {
            value = create();
            _cache.Set(cacheKey, value, TimeSpan.FromSeconds(cacheDurationInSeconds));
        }
        return value;
    }

    public void Remove<V>(string key)
    {
        _keys.Remove(key);
        _cache.Remove(key);
    }
}