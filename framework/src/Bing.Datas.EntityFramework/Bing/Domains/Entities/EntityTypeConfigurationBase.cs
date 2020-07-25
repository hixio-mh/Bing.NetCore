using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bing.Domains.Entities
{
    /// <summary>
    /// 数据实体映射配置基类
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <typeparam name="TDbContext">数据上下文类型</typeparam>
    public abstract class EntityTypeConfigurationBase<TEntity, TDbContext> : IEntityTypeConfiguration<TEntity>, IEntityRegister 
        where TEntity : class 
        where TDbContext : DbContext
    {
        /// <summary>
        /// 所属的上下文类型。如为null，将使用默认上下文，否则使用指定类型的上下文类型
        /// </summary>
        public Type DbContextType { get; }

        /// <summary>
        /// 实体类型
        /// </summary>
        public Type EntityType { get; }

        /// <summary>
        /// 初始化一个<see cref="EntityTypeConfigurationBase{TEntity,TDbContext}"/>类型的实例
        /// </summary>
        protected EntityTypeConfigurationBase()
        {
            DbContextType = typeof(TDbContext);
            EntityType = typeof(TEntity);
        }

        /// <summary>
        /// 将当前实体类映射对象注册到数据上下文模型构建器中
        /// </summary>
        /// <param name="builder">上下文模型构建器</param>
        public virtual void RegisterTo(ModelBuilder builder)
        {
            builder.ApplyConfiguration(this);
            if (typeof(IDelete).IsAssignableFrom(EntityType))
                builder.Entity<TEntity>().HasQueryFilter(m => ((IDelete)m).IsDeleted == false);
        }

        /// <summary>
        /// 重写以实现实体类型各个属性的数据库配置
        /// </summary>
        /// <param name="builder">实体类型创建器</param>
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            MapTable(builder);
            MapVersion(builder);
            MapProperties(builder);
            MapAssociations(builder);
        }

        /// <summary>
        /// 映射表
        /// </summary>
        /// <param name="builder">实体类型创建器</param>
        protected abstract void MapTable(EntityTypeBuilder<TEntity> builder);

        /// <summary>
        /// 映射乐观离线锁
        /// </summary>
        /// <param name="builder">实体类型创建器</param>
        protected virtual void MapVersion(EntityTypeBuilder<TEntity> builder) { }

        /// <summary>
        /// 映射属性
        /// </summary>
        /// <param name="builder">实体类型创建器</param>
        protected virtual void MapProperties(EntityTypeBuilder<TEntity> builder) { }

        /// <summary>
        /// 映射导航属性
        /// </summary>
        /// <param name="builder">实体类型创建器</param>
        protected virtual void MapAssociations(EntityTypeBuilder<TEntity> builder) { }

        /// <summary>
        /// 是否拥有乐观锁
        /// </summary>
        protected virtual bool HasVersion() => typeof(IVersion).IsAssignableFrom(EntityType);
    }
}
