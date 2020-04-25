using System;
using System.Threading.Tasks;

// ReSharper disable once CheckNamespace
namespace Bing.Serialization.Binary
{
    /// <summary>
    /// 二进制 扩展
    /// </summary>
    public static partial class BinaryExtensions
    {
        /// <summary>
        /// 从字节数组反序列化为对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="bytes">字节数组</param>
        public static T FromBytes<T>(this byte[] bytes) => BinaryHelper.Deserialize<T>(bytes);

        /// <summary>
        /// 从字节数组反序列化为对象
        /// </summary>
        /// <param name="bytes">字节数组</param>
        /// <param name="type">对象类型</param>
        public static object FromBytes(this byte[] bytes, Type type) => BinaryHelper.Deserialize(bytes);

        /// <summary>
        /// 从字节数组反序列化为对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="bytes">字节数组</param>
        public static Task<T> FromBytesAsync<T>(this byte[] bytes) => BinaryHelper.DeserializeAsync<T>(bytes);

        /// <summary>
        /// 从字节数组反序列化为对象
        /// </summary>
        /// <param name="bytes">字节数组</param>
        /// <param name="type">对象类型</param>
        public static Task<object> FromBytesAsync(this byte[] bytes, Type type) => BinaryHelper.DeserializeAsync(bytes);
    }
}
