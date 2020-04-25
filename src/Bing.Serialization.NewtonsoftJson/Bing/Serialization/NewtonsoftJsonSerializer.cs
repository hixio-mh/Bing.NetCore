using System;
using System.IO;
using System.Threading.Tasks;
using Bing.Serialization.Json.Newtonsoft;

namespace Bing.Serialization
{
    /// <summary>
    /// Newtonsoft Json 序列化器
    /// </summary>
    public class NewtonsoftJsonSerializer : IJsonSerializer
    {
        /// <summary>
        /// 序列化
        /// </summary>
        /// <typeparam name="T">序列化对象类型</typeparam>
        /// <param name="o">被序列化对象</param>
        public string Serialize<T>(T o) => JsonHelper.Serialize(o);

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <typeparam name="T">被序列化对象类型</typeparam>
        /// <param name="data">被反序列化对象</param>
        public T Deserialize<T>(string data) => JsonHelper.Deserialize<T>(data);

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="data">被反序列化对象</param>
        /// <param name="type">被序列化对象类型</param>
        public object Deserialize(string data, Type type) => JsonHelper.Deserialize(data, type);

        /// <summary>
        /// 序列化
        /// </summary>
        /// <typeparam name="T">序列化对象类型</typeparam>
        /// <param name="o">被序列化对象</param>
        public Task<string> SerializeAsync<T>(T o) => JsonHelper.SerializeAsync(o);

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <typeparam name="T">被序列化对象类型</typeparam>
        /// <param name="data">被反序列化对象</param>
        public Task<T> DeserializeAsync<T>(string data) => JsonHelper.DeserializeAsync<T>(data);

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="data">被反序列化对象</param>
        /// <param name="type">被序列化对象类型</param>
        public Task<object> DeserializeAsync(string data, Type type) => JsonHelper.DeserializeAsync(data, type);

        /// <summary>
        /// 序列化
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="o">对象</param>
        public Stream SerializeToStream<T>(T o) => JsonHelper.Pack(o);

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="stream">流</param>
        public T DeserializeFromStream<T>(Stream stream) => JsonHelper.Unpack<T>(stream);

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="stream">流</param>
        /// <param name="type">对象类型</param>
        public object DeserializeFromStream(Stream stream, Type type) => JsonHelper.Unpack(stream, type);

        /// <summary>
        /// 序列化
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="o">对象</param>
        public Task<Stream> SerializeToStreamAsync<T>(T o) => JsonHelper.PackAsync(o);

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="stream">流</param>
        public Task<T> DeserializeFromStreamAsync<T>(Stream stream) => JsonHelper.UnpackAsync<T>(stream);

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="stream">流</param>
        /// <param name="type">对象类型</param>
        public Task<object> DeserializeFromStreamAsync(Stream stream, Type type) => JsonHelper.UnpackAsync(stream, type);
    }
}
