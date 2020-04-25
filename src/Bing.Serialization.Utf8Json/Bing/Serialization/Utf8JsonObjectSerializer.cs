using System;
using System.IO;
using System.Threading.Tasks;
using Bing.Serialization.Json.Utf8Json;

namespace Bing.Serialization
{
    /// <summary>
    /// Utf8Json 序列化器
    /// </summary>
    public class Utf8JsonObjectSerializer : IJsonSerializer
    {
        /// <summary>
        /// 序列化
        /// </summary>
        /// <typeparam name="T">序列化对象类型</typeparam>
        /// <param name="o">被序列化对象</param>
        public string Serialize<T>(T o) => Utf8JsonHelper.Serialize(o);

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <typeparam name="T">被序列化对象类型</typeparam>
        /// <param name="data">被反序列化对象</param>
        public T Deserialize<T>(string data) => Utf8JsonHelper.Deserialize<T>(data);

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="data">被反序列化对象</param>
        /// <param name="type">被序列化对象类型</param>
        public object Deserialize(string data, Type type) => Utf8JsonHelper.Deserialize(data, type);

        /// <summary>
        /// 序列化
        /// </summary>
        /// <typeparam name="T">序列化对象类型</typeparam>
        /// <param name="o">被序列化对象</param>
        public async Task<string> SerializeAsync<T>(T o) => await Utf8JsonHelper.SerializeAsync(o);

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <typeparam name="T">被序列化对象类型</typeparam>
        /// <param name="data">被反序列化对象</param>
        public async Task<T> DeserializeAsync<T>(string data) => await Utf8JsonHelper.DeserializeAsync<T>(data);

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="data">被反序列化对象</param>
        /// <param name="type">被序列化对象类型</param>
        public async Task<object> DeserializeAsync(string data, Type type) => await Utf8JsonHelper.DeserializeAsync(data, type);

        /// <summary>
        /// 序列化
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="o">对象</param>
        public Stream SerializeToStream<T>(T o) => Utf8JsonHelper.Pack(o);

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="stream">流</param>
        public T DeserializeFromStream<T>(Stream stream) => Utf8JsonHelper.Unpack<T>(stream);

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="stream">流</param>
        /// <param name="type">对象类型</param>
        public object DeserializeFromStream(Stream stream, Type type) => Utf8JsonHelper.Unpack(stream, type);

        /// <summary>
        /// 序列化
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="o">对象</param>
        public Task<Stream> SerializeToStreamAsync<T>(T o) => Utf8JsonHelper.PackAsync(o);

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="stream">流</param>
        public Task<T> DeserializeFromStreamAsync<T>(Stream stream) => Utf8JsonHelper.UnpackAsync<T>(stream);

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="stream">流</param>
        /// <param name="type">对象类型</param>
        public Task<object> DeserializeFromStreamAsync(Stream stream, Type type) => Utf8JsonHelper.UnpackAsync(stream, type);
    }
}
