using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace ComponentUtil.Common.Data
{
    public static class EnumHelper
    {
        /// <summary>
        ///     获取枚举类型的描述
        /// </summary>
        /// <param name="value">枚举值</param>
        /// <returns>枚举描述</returns>
        public static string EnumDescription(Enum value)
        {
            var result = string.Empty;

            var fieldInfo = value.GetType().GetField(value.ToString());
            if (fieldInfo != null)
            {
                var attributes =
                    (DescriptionAttribute[]) fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attributes.Length > 0) result = attributes[0].Description;
            }

            return result;
        }

        /// <summary>
        ///     获取一个枚举定义的全部成员。
        /// </summary>
        /// <example>List&lt;EnumType&gt; types = Utilities.EnumItems&lt;EnumType&gt;()</example>
        /// <returns>枚举对象列表</returns>
        public static List<T> EnumItems<T>()
        {
            var enumType = typeof(T);

            return Enum.GetNames(enumType).Select(typeName => (T) Enum.Parse(enumType, typeName)).ToList();
        }

        /// <summary>
        ///     获取一个枚举的全部成员描述
        /// </summary>
        /// <returns>整个枚举的全部描述</returns>
        public static List<string> GetDescriptions<T>()
        {
            var result = new List<string>();
            var items = EnumItems<T>();

            foreach (var item in items)
            {
                var fieldInfo = item.GetType().GetField(item.ToString());
                if (fieldInfo != null)
                {
                    var attributes =
                        (DescriptionAttribute[]) fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

                    if (attributes.Length > 0) result.Add(attributes[0].Description);
                }
            }

            return result;
        }
    }
}