using System.Threading.Tasks;

namespace Bing.Auditing
{
    /// <summary>
    /// 审计数据存储器。
    /// 注意：审计操作的记录不能喝业务数据操作在同一事务中
    /// </summary>
    public interface IAuditingStore
    {
        Task SaveAsync();
    }
}
