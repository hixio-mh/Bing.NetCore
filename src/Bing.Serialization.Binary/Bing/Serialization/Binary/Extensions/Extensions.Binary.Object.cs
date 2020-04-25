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
        /// 转换为字节数组
        /// </summary>
        /// <param name="obj">对象</param>
        public static byte[] ToBytes(this object obj) => BinaryHelper.Serialize(obj);

        /// <summary>
        /// 转换为字节数组
        /// </summary>
        /// <param name="obj">对象</param>
        public static Task<byte[]> ToBytesAsync(this object obj) => BinaryHelper.SerializeAsync(obj);
    }
}
