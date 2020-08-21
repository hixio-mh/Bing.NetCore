using System;

namespace Bing.Admin.Data.UnitOfWorks.MySql
{
    /// <summary>
    /// 工作单元
    /// </summary>
    public class AdminUnitOfWork : Bing.Uow.UnitOfWork, IAdminUnitOfWork
    {
        /// <summary>
        /// 初始化一个<see cref="AdminUnitOfWork"/>类型的实例
        /// </summary>
        /// <param name="orm">FreeSql</param>
        /// <param name="serviceProvider">服务提供程序</param>
        public AdminUnitOfWork(IFreeSql orm, IServiceProvider serviceProvider = null) : base(orm, serviceProvider)
        {
        }
    }
}
