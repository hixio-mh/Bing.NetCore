using Bing.Admin.Systems.Domain.Models;
using FreeSql.Extensions.EfCoreFluentApi;

namespace Bing.Admin.Data.Mappings.Systems.MySql
{
    /// <summary>
    /// 资源 映射配置
    /// </summary>
    public class ResourceMap : Bing.FreeSQL.MySql.AggregateRootMap<Resource>
    {
        /// <summary>
        /// 映射表
        /// </summary>
        protected override void MapTable(EfCoreTableFluent<Resource> builder ) 
        {
            builder.ToTable( "`Systems.Resource`" );
        }
                
        /// <summary>
        /// 映射属性
        /// </summary>
        protected override void MapProperties(EfCoreTableFluent<Resource> builder ) 
        {
            // 资源标识
            builder.Property(t => t.Id)
                .HasColumnName("ResourceId");
            builder.Property( t => t.Path ).HasColumnName( "Path" );
            builder.Property( t => t.Level ).HasColumnName( "Level" );
        }
    }
}
