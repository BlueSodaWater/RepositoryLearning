using Blog.Core.Common;
using Blog.Core.Helper;
using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Core.AOP
{
    public class BlogCacheAOP : AOPbase
    {
        private readonly ICaching Cache;
        public BlogCacheAOP(ICaching cache)
        {
            this.Cache = cache;
        }

        public override void Intercept(IInvocation invocation)
        {
            var method = invocation.MethodInvocationTarget ?? invocation.Method;
            var qCachingAttribute = method.GetCustomAttributes(true).FirstOrDefault(
                x => x.GetType() == typeof(CachingAttribute)) as CachingAttribute;

            if (qCachingAttribute != null)
            {
                var cacheKey = CustomCacheKey(invocation);

                var cacheValue = Cache.Get(cacheKey);
                if (cacheValue != null)
                {
                    invocation.ReturnValue = cacheValue;
                    return;
                }

                invocation.Proceed();
                if (!string.IsNullOrWhiteSpace(cacheKey))
                {
                    Cache.Set(cacheKey, invocation.ReturnValue);
                }
            }
        }
    }
}
