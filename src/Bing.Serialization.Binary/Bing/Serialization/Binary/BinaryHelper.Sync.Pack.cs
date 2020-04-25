using System.IO;

namespace Bing.Serialization.Binary
{
    /// <summary>
    /// 二进制操作辅助类
    /// </summary>
    public static partial class BinaryHelper
    {
        /// <summary>
        /// 装箱
        /// </summary>
        /// <param name="obj">对象</param>
        public static Stream Pack(object obj)
        {
            var ms = new MemoryStream();
            if (obj != null)
                Pack(obj, ms);
            return ms;
        }

        /// <summary>
        /// 装箱
        /// </summary>
        /// <param name="obj">对象</param>
        /// <param name="stream">流</param>
        public static void Pack(object obj, Stream stream)
        {
            if (obj is null)
                return;
            BinaryManager.GetBinaryFormatter().Serialize(stream, obj);
        }

        /// <summary>
        /// 拆箱
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="stream">流</param>
        public static T Unpack<T>(Stream stream) => (T)Unpack(stream);

        /// <summary>
        /// 拆箱
        /// </summary>
        /// <param name="stream">流</param>
        public static object Unpack(Stream stream)
        {
            if (stream is null || stream.Length is 0)
                return null;
            if (stream.CanSeek && stream.Position > 0)
                stream.Position = 0;
            return BinaryManager.GetBinaryFormatter().Deserialize(stream);
        }
    }
}
