using System;

namespace Bing.Domains.Entities
{
    /// <summary>
    /// 定义实体管理器
    /// </summary>
    public interface IEntityManager
    {
        /// <summary>
        /// 初始化实体类型注册
        /// </summary>
        void Initialize();

        /// <summary>
        /// 获取指定上下文类型的实体配置注册信息
        /// </summary>
        /// <param name="dbContextType">数据上下文类型</param>
        IEntityRegister[] GetEntityRegisters(Type dbContextType);

        /// <summary>
        /// 获取实体类所属的数据上下文类
        /// </summary>
        /// <param name="entityType">实体类型</param>
        Type GetDbContextTypeForEntity(Type entityType);
    }
}
