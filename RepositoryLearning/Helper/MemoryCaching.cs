using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Core.Helper
{
    public class MemoryCaching : ICaching
    {
        private IMemoryCache Cache;

        public MemoryCaching(IMemoryCache cache)
        {
            this.Cache = cache;
        }

        public object Get(string cacheKey)
        {
            return Cache.Get(cacheKey);
        }

        public void Set(string cacheKey,object cacheValue)
        {
            Cache.Set(cacheKey, cacheValue, TimeSpan.FromSeconds(7200));
        }
    }
}
