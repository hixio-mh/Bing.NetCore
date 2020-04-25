using System;
using System.IO;
using System.Threading.Tasks;

namespace Bing.Serialization
{
    /// <summary>
    /// 对象序列化器
    /// </summary>
    public interface ISerializer
    {
        /// <summary>
        /// 序列化
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="o">对象</param>
        Stream SerializeToStream<T>(T o);

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="stream">流</param>
        T DeserializeFromStream<T>(Stream stream);

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="stream">流</param>
        /// <param name="type">对象类型</param>
        object DeserializeFromStream(Stream stream, Type type);

        /// <summary>
        /// 序列化
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="o">对象</param>
        Task<Stream> SerializeToStreamAsync<T>(T o);

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="stream">流</param>
        Task<T> DeserializeFromStreamAsync<T>(Stream stream);

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="stream">流</param>
        /// <param name="type">对象类型</param>
        Task<object> DeserializeFromStreamAsync(Stream stream, Type type);
    }
}
