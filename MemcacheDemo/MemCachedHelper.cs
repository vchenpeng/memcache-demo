using Enyim.Caching;
using Enyim.Caching.Configuration;
using Enyim.Caching.Memcached;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MemcacheDemo
{
    public sealed class MemCachedHelper
    {
        private static MemcachedClient MemClient;
        static readonly object padlock = new object();

        //线程安全的单例模式
        public static MemcachedClient getInstance()
        {
            if (MemClient == null)
            {
                lock (padlock)
                {
                    if (MemClient == null)
                    {
                        MemClientInit();
                    }
                }
            }
            return MemClient;
        }
        //初始化缓存
        static void MemClientInit()
        {
            try
            {
                MemClient = new MemcachedClient("enyim.com/memcached");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //构造函数
        static MemCachedHelper()
        {
            getInstance();
        }

        public static void Store(string Key, object Value, DateTime? ExpiredAt)
        {
            if (ExpiredAt.HasValue)
            {
                MemClient.Store(StoreMode.Set, Key, Value, ExpiredAt.Value);
            }
            else
            {
                MemClient.Store(StoreMode.Set, Key, Value);
            }
        }

        public static T Get<T>(string Key)
        {
            return MemClient.Get<T>(Key);
        }

        public static void Remove(string Key)
        {
            MemClient.Remove(Key);
        }

    }
}