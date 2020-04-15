using System;
using System.Globalization;
using Bing.Extensions;
using Bing.Helpers;

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
        /// <param name="defaultValue">默认值</param>
        public static object GetProperty(this IHasExtraProperties source, string name, object defaultValue = null) => source.ExtraProperties?.GetOrDefault(name) ?? defaultValue;

        /// <summary>
        /// 获取属性。仅支持基本类型
        /// </summary>
        /// <typeparam name="TProperty">属性类型</typeparam>
        /// <param name="source">源</param>
        /// <param name="name">名称</param>
        /// <param name="defaultValue">默认值</param>
        /// <exception cref="BingException"></exception>
        public static TProperty GetProperty<TProperty>(this IHasExtraProperties source, string name, TProperty defaultValue = default)
        {
            var value = source.GetProperty(name);
            if (value == null)
                return defaultValue;
            if (Reflection.IsPrimitiveExtended(typeof(TProperty), includeEnums: true))
                return (TProperty)Convert.ChangeType(value, typeof(TProperty), CultureInfo.InvariantCulture);
            throw new BingException("GetProperty<TProperty> does not support non-primitive types. Use non-generic GetProperty method and handle type casting manually.");
        }

        /// <summary>
        /// 设置属性
        /// </summary>
        /// <typeparam name="TSource">源类型</typeparam>
        /// <param name="source">源</param>
        /// <param name="name">名称</param>
        /// <param name="value">值</param>
        public static TSource SetProperty<TSource>(this TSource source, string name, object value) where TSource : IHasExtraProperties
        {
            source.ExtraProperties[name] = value;
            return source;
        }

        /// <summary>
        /// 移除属性
        /// </summary>
        /// <typeparam name="TSource">源类型</typeparam>
        /// <param name="source">源</param>
        /// <param name="name">名称</param>
        public static TSource RemoveProperty<TSource>(this TSource source, string name) where TSource : IHasExtraProperties
        {
            source.ExtraProperties.Remove(name);
            return source;
        }
    }
}
