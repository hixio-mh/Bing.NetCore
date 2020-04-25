using System.IO;
using System.Threading.Tasks;

// ReSharper disable once CheckNamespace
namespace Bing.Serialization.Binary
{
    /// <summary>
    /// 内部扩展
    /// </summary>
    internal static class InternalExtensions
    {
        /// <summary>
        /// 转换为字节数组
        /// </summary>
        /// <param name="stream">流</param>
        public static byte[] CastToBytes(this Stream stream)
        {
            var bytes = new byte[stream.Length];
            if (stream.CanSeek && stream.Position > 0)
                stream.Seek(0, SeekOrigin.Begin);
            stream.Read(bytes, 0, bytes.Length);
            if (stream.CanSeek)
                stream.Seek(0, SeekOrigin.Begin);
            return bytes;
        }

        /// <summary>
        /// 转换为字节数组
        /// </summary>
        /// <param name="stream">流</param>
        public static async Task<byte[]> CastToBytesAsync(this Stream stream)
        {
            var bytes = new byte[stream.Length];
            if (stream.Position > 0 && stream.CanSeek)
                stream.Seek(0, SeekOrigin.Begin);
            await stream.ReadAsync(bytes, 0, bytes.Length);
            if (stream.CanSeek)
                stream.Seek(0, SeekOrigin.Begin);
            return bytes;
        }
    }
}
