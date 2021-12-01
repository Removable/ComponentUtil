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
        
        /// <summary>
        /// 从时间戳转为日期
        /// </summary>
        /// <param name="timeStamp"></param>
        /// <returns></returns>
        public static DateTime? ToDateTime(long timeStamp)
        {
            var str = timeStamp.ToString();
            if (str.Length == 10)
            {
                return DateTimeOffset.FromUnixTimeSeconds(timeStamp).LocalDateTime;
            }
            else if (str.Length == 13)
            {
                return DateTimeOffset.FromUnixTimeMilliseconds(timeStamp).LocalDateTime;
            }
            else return null;
        }
    }
}