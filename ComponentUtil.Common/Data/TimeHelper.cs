using System;

namespace ComponentUtil.Common.Data
{
    public enum EnumTimeStampType
    {
        /// <summary>
        /// 按秒计算
        /// </summary>
        Seconds,

        /// <summary>
        /// 按毫秒计算
        /// </summary>
        Milliseconds,
    }

    public static class TimeHelper
    {
        /// <summary>
        /// 获取时间戳
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="tsType">时间戳类型（秒、毫秒）</param>
        /// <returns></returns>
        public static long GetTimeStamp(this DateTime dateTime, EnumTimeStampType tsType = EnumTimeStampType.Seconds)
        {
            return tsType switch
            {
                EnumTimeStampType.Milliseconds => new DateTimeOffset(dateTime).ToUnixTimeMilliseconds(),
                EnumTimeStampType.Seconds => new DateTimeOffset(dateTime).ToUnixTimeSeconds(),
                _ => new DateTimeOffset(dateTime).ToUnixTimeSeconds(),
            };
        }
    }
}