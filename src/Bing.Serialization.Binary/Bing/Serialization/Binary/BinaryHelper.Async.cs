using System.IO;
using System.Threading.Tasks;

namespace Bing.Serialization.Binary
{
    /// <summary>
    /// 二进制操作辅助类
    /// </summary>
    public static partial class BinaryHelper
    {
        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="obj">对象</param>
        public static async Task<byte[]> SerializeAsync(object obj)
        {
            using var stream = await PackAsync(obj);
            return await stream.CastToBytesAsync();
        }

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="bytes">数据</param>
        public static async Task<T> DeserializeAsync<T>(byte[] bytes) => (T)await DeserializeAsync(bytes);

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="bytes">数据</param>
        public static async Task<object> DeserializeAsync(byte[] bytes)
        {
            if (bytes is null || bytes.Length is 0)
                return default;
            using var ms = new MemoryStream(bytes);
            return await UnpackAsync(ms);
        }
    }
}
