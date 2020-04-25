using System;
using System.Runtime.Serialization.Formatters.Binary;

namespace Bing.Serialization.Binary
{
    /// <summary>
    /// 二进制管理器
    /// </summary>
    internal static class BinaryManager
    {
        /// <summary>
        /// 二进制格式化器
        /// </summary>
        [ThreadStatic]
        private static BinaryFormatter _binaryFormatter;

        /// <summary>
        /// 获取二进制格式化器
        /// </summary>
        public static BinaryFormatter GetBinaryFormatter() => _binaryFormatter ??= new BinaryFormatter();
    }
}
