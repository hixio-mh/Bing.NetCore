using System;
using System.IO;
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
        /// 装箱
        /// </summary>
        /// <param name="obj">对象</param>
        public static Stream Pack(this object obj) => BinaryHelper.Pack(obj);

        /// <summary>
        /// 装箱
        /// </summary>
        /// <param name="obj">对象</param>
        /// <param name="stream">流</param>
        public static void PackTo(this object obj, Stream stream) => BinaryHelper.Pack(obj, stream);

        /// <summary>
        /// 装箱
        /// </summary>
        /// <param name="obj">对象</param>
        public static Task<Stream> PackAsync(this object obj) => BinaryHelper.PackAsync(obj);

        /// <summary>
        /// 装箱
        /// </summary>
        /// <param name="obj">对象</param>
        /// <param name="stream">流</param>
        public static Task PackToAsync(this object obj, Stream stream) => BinaryHelper.PackAsync(obj, stream);

        /// <summary>
        /// 装箱
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="stream">流</param>
        /// <param name="obj">对象</param>
        public static void PackBy<T>(this Stream stream, T obj) => BinaryHelper.Pack(obj, stream);

        /// <summary>
        /// 拆箱
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="stream">流</param>
        public static T Unpack<T>(this Stream stream) => BinaryHelper.Unpack<T>(stream);

        /// <summary>
        /// 拆箱
        /// </summary>
        /// <param name="stream">流</param>
        /// <param name="type">对象类型</param>
        public static object Unpack(this Stream stream, Type type) => BinaryHelper.Unpack(stream);

        /// <summary>
        /// 装箱
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="stream">流</param>
        /// <param name="obj">对象</param>
        public static Task PackByAsync<T>(this Stream stream, T obj) => BinaryHelper.PackAsync(obj, stream);

        /// <summary>
        /// 拆箱
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="stream">流</param>
        public static Task<T> UnpackAsync<T>(this Stream stream) => BinaryHelper.UnpackAsync<T>(stream);

        /// <summary>
        /// 拆箱
        /// </summary>
        /// <param name="stream">流</param>
        /// <param name="type">对象类型</param>
        public static Task<object> UnpackAsync(this Stream stream, Type type) => BinaryHelper.UnpackAsync(stream);
    }
}
