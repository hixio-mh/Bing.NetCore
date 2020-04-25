using System.IO;

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
        public static byte[] Serialize(object obj)
        {
            using var stream = Pack(obj);
            return stream.CastToBytes();
        }

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="bytes">数据</param>
        public static T Deserialize<T>(byte[] bytes) => (T)Deserialize(bytes);

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="bytes">数据</param>
        public static object Deserialize(byte[] bytes)
        {
            if (bytes is null || bytes.Length is 0)
                return default;
            using var ms = new MemoryStream(bytes);
            return Unpack(ms);
        }
    }
}
