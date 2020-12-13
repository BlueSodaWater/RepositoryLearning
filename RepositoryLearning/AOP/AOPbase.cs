﻿using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.AOP
{
    public abstract class AOPbase : IInterceptor
    {
        public abstract void Intercept(IInvocation invocation);

        protected string CustomCacheKey(IInvocation invocation)
        {
            var typeName = invocation.TargetType.Name;
            var methodName = invocation.Method.Name;
            var methodArguments = invocation.Arguments.Select(GetArgumentValue).Take(3).ToList();

            string key = $"{typeName}:{methodName}:";
            foreach (var param in methodArguments)
            {
                key = $"{key}{param}:";
            }

            return key.TrimEnd(':');
        }

        protected static string GetArgumentValue(object arg)
        {
            if (arg is DateTime || arg is DateTime?)
                return ((DateTime)arg).ToString("yyyyMMddHHmmss");

            if (arg is string || arg is ValueType || arg is Nullable)
                return arg.ToString();

            if(arg != null)
            {
                if (arg.GetType().IsClass)
                {
                    return MD5Encrypt16(Newtonsoft.Json.JsonConvert.SerializeObject(arg));
                }
            }

            return string.Empty;
        }

        public static string MD5Encrypt16(string password)
        {
            var md5 = new MD5CryptoServiceProvider();
            string t2 = BitConverter.ToString(md5.ComputeHash(Encoding.Default.GetBytes(password)), 4, 8);
            t2 = t2.Replace("-", string.Empty);
            return t2;
        }
    }
}
