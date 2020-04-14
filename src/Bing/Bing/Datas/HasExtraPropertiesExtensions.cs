using System;
using System.Collections.Generic;
using System.Text;
using Bing.Extensions;

namespace Bing.Datas
{
    /// <summary>
    /// 额外属性(<see cref="IHasExtraProperties"/>) 扩展
    /// </summary>
    public static class HasExtraPropertiesExtensions
    {
        /// <summary>
        /// 是否包含指定名称的属性
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="name">名称</param>
        public static bool HasProperty(this IHasExtraProperties source, string name) => source.ExtraProperties.ContainsKey(name);

        /// <summary>
        /// 获取指定名称的属性
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="name">名称</param>
        public static object GetProperty(this IHasExtraProperties source, string name) => source.ExtraProperties?.GetOrDefault(name);

        public static TProperty GetProperty<TProperty>(this IHasExtraProperties source, string name)
        {
            var value = source.GetProperty(name);
            if (value == default)
                return default;
        }
    }
}
