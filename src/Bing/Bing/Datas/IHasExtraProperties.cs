using System.Collections.Generic;

namespace Bing.Datas
{
    /// <summary>
    /// 额外属性
    /// </summary>
    public interface IHasExtraProperties
    {
        /// <summary>
        /// 额外属性
        /// </summary>
        Dictionary<string, object> ExtraProperties { get; }
    }
}
