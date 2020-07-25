using System;
using Microsoft.EntityFrameworkCore;

namespace Bing.Domains.Entities
{
    /// <summary>
    /// 定义将实体配置类注册到上下文中
    /// </summary>
    public interface IEntityRegister
    {
        /// <summary>
        /// 所属的上下文类型。如为null，将使用默认上下文，否则使用指定类型的上下文类型
        /// </summary>
        Type DbContextType { get; }

        /// <summary>
        /// 实体类型
        /// </summary>
        Type EntityType { get; }

        /// <summary>
        /// 将当前实体类映射对象注册到数据上下文模型构建器中
        /// </summary>
        /// <param name="builder">上下文模型构建器</param>
        void RegisterTo(ModelBuilder builder);
    }
}
