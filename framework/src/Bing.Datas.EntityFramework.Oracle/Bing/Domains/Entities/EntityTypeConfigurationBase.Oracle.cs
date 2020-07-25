using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bing.Domains.Entities
{
    /// <summary>
    /// 数据实体映射配置基类
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <typeparam name="TDbContext">数据上下文类型</typeparam>
    public abstract class OracleEntityTypeConfigurationBase<TEntity, TDbContext> : EntityTypeConfigurationBase<TEntity, TDbContext> 
        where TEntity : class 
        where TDbContext : DbContext
    {
        /// <summary>
        /// 映射乐观离线锁
        /// </summary>
        /// <param name="builder">实体类型创建器</param>
        protected override void MapVersion(EntityTypeBuilder<TEntity> builder)
        {
            if(!HasVersion())
                return;
            builder.Property(nameof(IVersion.Version)).IsConcurrencyToken();
        }
    }
}
