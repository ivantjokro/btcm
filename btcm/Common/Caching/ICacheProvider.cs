using System;

namespace btcm.Common.Caching
{
    public interface ICacheProvider
    {
        T Get<T>(string key, Func<T> fetch, bool hasDependency = false) where T : class;
    }
}
