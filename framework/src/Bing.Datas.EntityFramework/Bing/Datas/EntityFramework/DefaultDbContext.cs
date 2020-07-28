using System;
using Bing.Datas.EntityFramework.Core;
using Microsoft.EntityFrameworkCore;

namespace Bing.Datas.EntityFramework
{
    /// <summary>
    /// 默认EntityFramework数据上下文
    /// </summary>
    public class DefaultDbContext : UnitOfWorkBase
    {
        /// <summary>
        /// 初始化一个<see cref="DefaultDbContext"/>类型的实例
        /// </summary>
        /// <param name="options">配置</param>
        /// <param name="serviceProvider">服务提供器</param>
        public DefaultDbContext(DbContextOptions options, IServiceProvider serviceProvider) : base(options, serviceProvider)
        {
        }
    }
}
