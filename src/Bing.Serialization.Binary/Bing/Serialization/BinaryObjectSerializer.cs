using System;
using System.IO;
using System.Threading.Tasks;
using Bing.Serialization.Binary;

namespace Bing.Serialization
{
    /// <summary>
    /// 二进制对象序列化器
    /// </summary>
    public class BinaryObjectSerializer : IObjectSerializer<byte[]>
    {
        /// <summary>
        /// 序列化
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="o">对象</param>
        public Stream SerializeToStream<T>(T o) => BinaryHelper.Pack(o);

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="stream">流</param>
        public T DeserializeFromStream<T>(Stream stream) => BinaryHelper.Unpack<T>(stream);

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="stream">流</param>
        /// <param name="type">对象类型</param>
        public object DeserializeFromStream(Stream stream, Type type) => BinaryHelper.Unpack(stream);

        /// <summary>
        /// 序列化
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="o">对象</param>
        public Task<Stream> SerializeToStreamAsync<T>(T o) => BinaryHelper.PackAsync(o);

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="stream">流</param>
        public Task<T> DeserializeFromStreamAsync<T>(Stream stream) => BinaryHelper.UnpackAsync<T>(stream);

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="stream">流</param>
        /// <param name="type">对象类型</param>
        public Task<object> DeserializeFromStreamAsync(Stream stream, Type type) => BinaryHelper.UnpackAsync(stream);

        /// <summary>
        /// 序列化
        /// </summary>
        /// <typeparam name="T">序列化对象类型</typeparam>
        /// <param name="o">被序列化对象</param>
        public byte[] Serialize<T>(T o) => BinaryHelper.Serialize(o);

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <typeparam name="T">被序列化对象类型</typeparam>
        /// <param name="data">被反序列化对象</param>
        public T Deserialize<T>(byte[] data) => BinaryHelper.Deserialize<T>(data);

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="data">被反序列化对象</param>
        /// <param name="type">被序列化对象类型</param>
        public object Deserialize(byte[] data, Type type) => BinaryHelper.Deserialize(data);

        /// <summary>
        /// 序列化
        /// </summary>
        /// <typeparam name="T">序列化对象类型</typeparam>
        /// <param name="o">被序列化对象</param>
        public Task<byte[]> SerializeAsync<T>(T o) => BinaryHelper.SerializeAsync(o);

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <typeparam name="T">被序列化对象类型</typeparam>
        /// <param name="data">被反序列化对象</param>
        public Task<T> DeserializeAsync<T>(byte[] data) => BinaryHelper.DeserializeAsync<T>(data);

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="data">被反序列化对象</param>
        /// <param name="type">被序列化对象类型</param>
        public Task<object> DeserializeAsync(byte[] data, Type type) => BinaryHelper.DeserializeAsync(data);
    }
}
