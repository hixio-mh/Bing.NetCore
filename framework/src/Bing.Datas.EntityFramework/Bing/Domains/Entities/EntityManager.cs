using System;
using System.Collections.Concurrent;
using System.Linq;
using Bing.Datas.EntityFramework;

namespace Bing.Domains.Entities
{
    /// <summary>
    /// 实体管理器
    /// </summary>
    public class EntityManager : IEntityManager
    {
        /// <summary>
        /// 实体注册字典
        /// </summary>
        private readonly ConcurrentDictionary<Type, IEntityRegister[]> _entityRegistersDict = new ConcurrentDictionary<Type, IEntityRegister[]>();

        /// <summary>
        /// 实体配置类型查找器
        /// </summary>
        private readonly IEntityConfigurationTypeFinder _typeFinder;

        /// <summary>
        /// 是否已初始化
        /// </summary>
        private bool _initialized;

        /// <summary>
        /// 初始化一个<see cref="EntityManager"/>类型的实例
        /// </summary>
        /// <param name="typeFinder">实体配置类型查找器</param>
        public EntityManager(IEntityConfigurationTypeFinder typeFinder)
        {
            _typeFinder = typeFinder;
        }

        /// <summary>
        /// 初始化实体类型注册
        /// </summary>
        public virtual void Initialize()
        {
            var dict = _entityRegistersDict;
            var types = _typeFinder.FindAll(true);
            if (types.Length == 0 || _initialized)
                return;
            dict.Clear();
            var registers = types.Select(type => Activator.CreateInstance(type) as IEntityRegister).ToList();
            var groups = registers.GroupBy(m => m.DbContextType).ToList();
            Type key;
            foreach (var group in groups)
            {
                key = group.Key ?? typeof(DefaultDbContext);

            }
        }

        /// <summary>
        /// 获取指定上下文类型的实体配置注册信息
        /// </summary>
        /// <param name="dbContextType">数据上下文类型</param>
        public IEntityRegister[] GetEntityRegisters(Type dbContextType)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取实体类所属的数据上下文类
        /// </summary>
        /// <param name="entityType">实体类型</param>
        public Type GetDbContextTypeForEntity(Type entityType)
        {
            throw new NotImplementedException();
        }
    }
}
