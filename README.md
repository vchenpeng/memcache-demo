memcache demo

### 示例
> .NET中memcache基本操作   
> 版本 v1.4.5  
> Enyim.Caching.Configuration.MemcachedClientSection, Enyim.Caching

### TEST

```csharp
MemcacheDemo.MemCachedHelper.Get<T>("key");
MemcacheDemo.MemCachedHelper.Store("key", value);
MemcacheDemo.MemCachedHelper.Store("key", value, DateTime.Now.AddSeconds(5));
```

### 结合windows service
> 服务程序依赖 and 内存共享