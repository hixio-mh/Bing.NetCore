namespace Bing.ExceptionHandling
{
    /// <summary>
    /// 错误码
    /// </summary>
    public interface IHasErrorCode
    {
        /// <summary>
        /// 错误码
        /// </summary>
        long Code { get; }
    }
}
