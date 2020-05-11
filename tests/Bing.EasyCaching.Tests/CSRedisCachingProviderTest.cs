using System;
using System.Collections.Generic;
using Bing.Caching;
using Bing.Tests;
using Bing.Tests.Samples;
using Bing.Utils.Json;
using CSRedis;
using EasyCaching.Core;
using EasyCaching.CSRedis;
using EasyCaching.Serialization.Json;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Xunit.Abstractions;

namespace Bing.EasyCaching.Tests
{
    /// <summary>
    /// CSRedis 缓存提供程序测试
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public class CSRedisCachingProviderTest : TestBase
    {
        /// <summary>
        /// 服务提供程序
        /// </summary>
        private readonly IServiceProvider _serviceProvider;

        /// <summary>
        /// 缓存
        /// </summary>
        private readonly ICache _cache;

        /// <summary>
        /// Redis缓存提供程序
        /// </summary>
        private readonly IRedisCachingProvider _redisCachingProvider;

        /// <summary>
        /// 初始化一个<see cref="TestBase"/>类型的实例
        /// </summary>
        public CSRedisCachingProviderTest(ITestOutputHelper output) : base(output)
        {
            var services = new ServiceCollection();
            services.AddCaching(o =>
            {
                o.UseCSRedis(config =>
                    {
                        // 互斥锁的存活时间。默认值:5000
                        config.LockMs = 5000;
                        // 预防缓存在同一时间全部失效，可以为每个key的过期时间添加一个随机的秒数。默认值:120秒
                        config.MaxRdSecond = 0;
                        // 是否开启日志。默认值:false
                        config.EnableLogging = false;
                        // 没有获取到互斥锁时的休眠时间。默认值:300毫秒
                        config.SleepMs = 300;
                        config.DBConfig = new CSRedisDBOptions()
                        {
                            ConnectionStrings = new List<string>()
                            {
                                "127.0.0.1:6379,defaultDatabase=0,poolsize=1"
                            }
                        };
                        config.SerializerName = "json";
                    })
                    .WithJson("json");
            });
            RedisHelper.Initialization(new CSRedisClient("127.0.0.1:6379,defaultDatabase=0,poolsize=1"));
            _serviceProvider = services.BuildServiceProvider();
            _cache = _serviceProvider.GetService<ICache>();
            _redisCachingProvider = _serviceProvider.GetService<IRedisCachingProvider>();
        }

        /// <summary>
        /// 测试 是否存在指定键的缓存 - 不存在
        /// </summary>
        [Fact]
        public void Test_Exists_False()
        {
            var key = "key:exists_false";
            var result = _cache.Exists(key);
            Assert.False(result);
        }

        /// <summary>
        /// 测试 是否存在指定键的缓存 - 存在
        /// </summary>
        [Fact]
        public void Test_Exists_True()
        {
            var key = "key:exists_true";
            _cache.TryAdd(key, new Sample3() { StringValue = "demo" });
            var result = _cache.Exists(key);
            Assert.True(result);
        }

        /// <summary>
        /// 测试 获取或添加缓存 - 相同对象
        /// </summary>
        [Fact]
        public void Test_GetOrAdd()
        {
            var key = "key:get_or_add";
            var result = _cache.Get<Sample3>(key);
            if (result == null)
                _cache.Add(key, new Sample3() { StringValue = "隔壁老王" });
            result = _cache.Get<Sample3>(key);
            Output.WriteLine(result.ToJson());
            Assert.Equal("隔壁老王", result.StringValue);
        }

        /// <summary>
        /// 测试 获取或添加缓存 - 不同对象
        /// </summary>
        [Fact]
        public void Test_GetOrAdd_OtherObject()
        {
            var key = "key:get_or_add_other";
            var result = _cache.Get<Sample3>(key);
            if (result == null)
                _cache.Add(key, new Sample3() { StringValue = "隔壁老王" });
            result = _cache.Get<Sample3>(key);
            Output.WriteLine(result.ToJson());
            Assert.Equal("隔壁老王", result.StringValue);
        }

        /// <summary>
        /// 测试 获取或添加缓存 - 不同对象
        /// </summary>
        [Fact]
        public void Test_GetOrAdd_OtherObject_Redis()
        {
            var key = "key:get_or_add_other_redis";
            var result = _redisCachingProvider.StringGet(key)?.ToObject<Sample3Copy>();
            if (result == null)
            {
                _redisCachingProvider.StringSet(key, new Sample3 { StringValue = "隔壁老王" }.ToJson());
                result = _redisCachingProvider.StringGet(key)?.ToObject<Sample3Copy>();
            }
            Output.WriteLine(result?.ToJson());
            var csRedisResult = RedisHelper.Get<Sample3Copy>("key:get_or_add_other_redis");
            Output.WriteLine(csRedisResult?.ToJson());
            Assert.Equal("隔壁老王", result?.StringValue);
            Assert.Equal("隔壁老王",csRedisResult?.StringValue);
        }
    }
}
