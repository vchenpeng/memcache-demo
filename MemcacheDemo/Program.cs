//注意：不要使用1.4.4版本，有设置过期时间的bug；当前使用1.4.5版本测试
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

using System.Runtime.Caching;

namespace MemcacheDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //MemcachedClient client = new MemcachedClient("enyim.com/memcached");

            ////-- 新增或更新，存在key, 则覆盖
            //client.ExecuteStore(StoreMode.Set, "test-set-key1", "whatever set 1");
            ////-- 新增或更新，存在key, 则覆盖: 指定有效期 1 小时
            //client.ExecuteStore(StoreMode.Set, "test-set-key2", "whatever set 2", DateTime.Now.AddHours(1));


            ////-- 新增， 存在该key, 则不覆盖
            //client.ExecuteStore(StoreMode.Add, "test-add-key1", "whatever add 1");

            ////-- 更新， 不存在该key, 则不做更新
            //client.ExecuteStore(StoreMode.Replace, "test-replace-key1", "whatever replace key1");


            ////-- 取值
            //client.Get<string>("test-set-key1"); // whatever set 1
            //client.Get<string>("test-add-key1"); // whatever add 1


            ////-- 缓存对象: 对象必须可序列化

            //Foo foo = new Foo { Id = 1, Name = "foo1" };
            //client.ExecuteStore(StoreMode.Set, "obj1", foo, DateTime.Now.AddHours(1));

            ////取值
            //var cacheFoo = client.Get<Foo>("obj1");

            //Console.WriteLine(cacheFoo);

            //MemcachedClient client = new MemcachedClient("enyim.com/memcached");
            //client.FlushAll();
            //存值  --不带过期时间的存储，Memcached将根据LRU来决定过期策略

            //for (int i = 1; i <= 20; i++)
            //{
            //    client.Remove("name" + i);
            //}

            //var obj = new Foo
            //{
            //    Id = 1,
            //    Name = Guid.NewGuid().ToString(),
            //    Time = DateTime.Now
            //};
            //bool result = client.Store(Enyim.Caching.Memcached.StoreMode.Add, "name8", obj);



            //client.Store(Enyim.Caching.Memcached.StoreMode.Add, "name2", "dinglang2");
            //client.Store(Enyim.Caching.Memcached.StoreMode.Add, "name3", "dinglang3");
            //带过期时间的缓存  
            //bool success = client.Store(StoreMode.Add, person.UserName, person, DateTime.Now.AddMinutes(10)); 
            //if (result)
            //{
            //    Console.WriteLine("成功存入缓存");

            //    //取值  
            //    object name = client.Get("name8");
            //    if (name != null)
            //    {
            //        Console.WriteLine("取出的值为:" + JsonConvert.SerializeObject(name));
            //    }
            //    else
            //    {
            //        Console.WriteLine("取值失败");
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("存入缓存失败");
            //}

            //Finish:
            //var o = client.Get<Foo>("name8");
            //if (o != null)
            //{
            //    Foo a = o as Foo;
            //    a.Id++;
            //    //TimeSpan ts = new TimeSpan(1000 * 5);
            //    client.Store(StoreMode.Set, "name8", a);
            //    Console.WriteLine("从缓存获取：\r\n" + JsonConvert.SerializeObject(o));
            //}
            //else
            //{
            //    Console.WriteLine("缓存没有，准备去访问数据库...");
            //    var obj2 = new Foo
            //    {
            //        Id = 0,
            //        Name = Guid.NewGuid().ToString(),
            //        Time = DateTime.Now.ToLongTimeString()
            //    };
            //    bool result2 = client.Store(Enyim.Caching.Memcached.StoreMode.Set, "name8", obj2, DateTime.Now.AddDays(1));
            //    if (result2)
            //    {
            //        Console.WriteLine("从数据库获取成功：\r\n" + JsonConvert.SerializeObject(obj2));
            //    }
            //    else
            //    {
            //        Console.WriteLine("从数据库获取失败");
            //    }
            //}
            //Console.ReadKey();

            //goto Finish;

            //ObjectCache cache = MemoryCache.Default;
            //CacheItemPolicy policy = new CacheItemPolicy();
            //policy.Priority = CacheItemPriority.NotRemovable;
            //Console.Write("输入卡号：");
            //string no = Console.ReadLine();
            
            //cache.Set("WdcCardNo", no, policy);


            Finish:
            var value1 = MemcacheDemo.MemCachedHelper.Get<Foo>("key1");
            if (value1 != null)
            {
                Console.WriteLine("从缓存获取：\r\n" + JsonConvert.SerializeObject(value1));
                //value1.Id++;

                //MemcacheDemo.MemCachedHelper.Store("key1", value1, null);
            }
            else
            {
                Console.WriteLine("缓存没有，准备去访问数据库...");
                var obj2 = new Foo
                {
                    Id = 0,
                    Name = Guid.NewGuid().ToString(),
                    Time = DateTime.Now.ToLongTimeString()
                };
                MemcacheDemo.MemCachedHelper.Store("key1", obj2, DateTime.Now.AddSeconds(5));
                Console.WriteLine("从数据库获取成功：\r\n" + JsonConvert.SerializeObject(obj2));
            }
            Console.ReadKey();
            goto Finish;

            //var temp = cache.Get("WdcCardNo");
            //Console.WriteLine("我点餐卡号：" + temp);
            Console.ReadKey();
        }
    }

    [Serializable]
    //[KnowTypeAttribute]
    public class Foo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Time { get; set; }
    }
}
