using System;
using System.Runtime.Serialization;
using Bing.ExceptionHandling;
using Bing.Exceptions;
using Bing.Logging;
using Bing.Logs;

namespace Bing
{
    /// <summary>
    /// 业务异常
    /// </summary>
    public class BusinessException : BingException
        , IBusinessException
        , IHasErrorCode
        , IHasErrorDetails
        , IHasLogLevel
    {
        /// <summary>
        /// 标识
        /// </summary>
        private const string FLAG = "__BUSINESS_FLG";

        /// <summary>
        /// 默认消息
        /// </summary>
        private const string DEFAULT_MESSAGE = "业务异常";

        /// <summary>
        /// 默认编码
        /// </summary>
        private const long DEFAULT_CODE = 1201;

        /// <summary>
        /// 初始化一个<see cref="BusinessException"/>类型的实例
        /// </summary>
        public BusinessException() : base(DEFAULT_CODE, DEFAULT_MESSAGE, FLAG) { }

        /// <summary>
        /// 初始化一个<see cref="BusinessException"/>类型的实例
        /// </summary>
        /// <param name="message">错误消息</param>
        public BusinessException(string message) : base(DEFAULT_CODE, message, FLAG) { }

        /// <summary>
        /// 初始化一个<see cref="BusinessException"/>类型的实例
        /// </summary>
        /// <param name="code">错误码</param>
        /// <param name="message">错误消息</param>
        public BusinessException(long code, string message) : base(code, message, FLAG) { }

        /// <summary>
        /// 初始化一个<see cref="BusinessException"/>类型的实例
        /// </summary>
        /// <param name="code">错误码</param>
        /// <param name="message">消息</param>
        /// <param name="details">错误详情</param>
        /// <param name="innerException">内部异常</param>
        /// <param name="logLevel">日志级别</param>
        public BusinessException(
            long? code = null
            , string message = null
            , string details = null
            , Exception innerException = null
            , LogLevel logLevel = LogLevel.Warning) 
            : base(code ?? DEFAULT_CODE, message ?? DEFAULT_MESSAGE, FLAG, innerException)
        {
            Details = details;
            LogLevel = logLevel;
        }

        /// <summary>
        /// 初始化一个<see cref="BusinessException"/>类型的实例
        /// </summary>
        /// <param name="info">序列化信息</param>
        /// <param name="context">流上下文</param>
        public BusinessException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            Code = DEFAULT_CODE;
            Flag = FLAG;
        }

        /// <summary>
        /// 错误详情
        /// </summary>
        public string Details { get; set; }

        /// <summary>
        /// 日志级别
        /// </summary>
        public LogLevel LogLevel { get; set; }

        /// <summary>
        /// 设置数据
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="value">值</param>
        public BusinessException WithData(string name, object value)
        {
            Data[name] = value;
            return this;
        }
    }
}
