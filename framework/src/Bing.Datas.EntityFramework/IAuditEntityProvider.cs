using System.Collections.Generic;
using Bing.Auditing;
using Microsoft.EntityFrameworkCore;

namespace Bing.Datas.EntityFramework
{
    /// <summary>
    /// 数据审计信息提供程序
    /// </summary>
    public interface IAuditEntityProvider
    {
        /// <summary>
        /// 获取数据审计信息
        /// </summary>
        /// <param name="context">数据上下文</param>
        IEnumerable<AuditEntityEntry> GetAuditEntities(DbContext context);
    }
}
