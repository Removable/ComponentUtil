using System;
using System.ComponentModel;

namespace ComponentUtil.Common.Data
{
    public static class TypeParseHelper
    {
        /// <summary>
        /// 转为int类型，转换失败则返回默认值
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultVal">默认值</param>
        /// <returns></returns>
        public static int ToInt(this object obj, int defaultVal)
        {
            try
            {
                return System.Convert.ToInt32(obj);
            }
            catch
            {
                return defaultVal;
            }
        }

        /// <summary>
        /// 转为decimal类型，转换失败则返回默认值
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultVal">默认值</param>
        /// <returns></returns>
        public static decimal ToDecimal(this object obj, decimal defaultVal)
        {
            try
            {
                return System.Convert.ToDecimal(obj);
            }
            catch
            {
                return defaultVal;
            }
        }

        /// <summary>
        /// 从string转为指定类型
        /// </summary>
        /// <param name="str">要转换的字符串值</param>
        /// <typeparam name="T">指定类型</typeparam>
        /// <returns></returns>
        public static T Convert<T>(string str)
        {
            var converter = TypeDescriptor.GetConverter(typeof(T));
            return (T)converter.ConvertFromString(str);
        }
    }
}