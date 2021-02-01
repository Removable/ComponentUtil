using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace ComponentUtil.Common.Data
{
    public static class EnumHelper
    {
        /// <summary>
        ///     获取枚举类型的描述
        /// </summary>
        /// <param name="value">枚举值</param>
        /// <returns>枚举描述</returns>
        public static string GetDescription(this Enum value)
        {
            var result = string.Empty;

            var fieldInfo = value.GetType().GetField(value.ToString());
            if (fieldInfo != null)
            {
                var attributes =
                    (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attributes.Length > 0) result = attributes[0].Description;
            }

            return result;
        }

        /// <summary>
        ///     获取一个枚举定义的全部成员。
        /// </summary>
        /// <example>List&lt;EnumType&gt; types = Utilities.EnumItems&lt;EnumType&gt;()</example>
        /// <returns>枚举对象列表</returns>
        public static List<T> GetEnumItems<T>()
        {
            var enumType = typeof(T);

            return Enum.GetNames(enumType).Select(typeName => (T)Enum.Parse(enumType, typeName)).ToList();
        }

        /// <summary>
        ///     获取一个枚举的全部成员描述
        /// </summary>
        /// <returns>整个枚举的全部描述</returns>
        public static List<string> GetAllDescriptions<T>()
        {
            var result = new List<string>();
            var items = GetEnumItems<T>();

            foreach (var item in items)
            {
                var fieldInfo = item.GetType().GetField(item.ToString());
                if (fieldInfo != null)
                {
                    var attributes =
                        (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

                    if (attributes.Length > 0) result.Add(attributes[0].Description);
                }
            }

            return result;
        }

        /// <summary>
        ///     获取一个枚举的全部成员描述
        /// </summary>
        /// <returns>整个枚举的全部描述</returns>
        public static List<(T enumItem, string description)> GetAllItemsAndDescriptions<T>()
        {
            var result = new List<(T, string)>();
            var items = GetEnumItems<T>();

            foreach (var item in items)
            {
                var fieldInfo = item.GetType().GetField(item.ToString());
                if (fieldInfo != null)
                {
                    var attributes =
                        (DescriptionAttribute[]) fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

                    if (attributes.Length > 0) result.Add((item, attributes[0].Description));
                }
            }

            return result;
        }

        /// <summary>
        /// 通过反射获取枚举所有项的值和描述
        /// </summary>
        /// <param name="assemblyName">程序集名称</param>
        /// <param name="enumName">指定的枚举完全名称（包括命名空间）</param>
        /// <returns></returns>
        public static List<(int value, string description)> GetEnumAllItemsByReflection(string assemblyName, string enumName)
        {
            var assembly = Assembly.Load(assemblyName);
            if (assembly == null) return null;

            var enumType = assembly.GetType(enumName);
            if (enumType == null) return null;

            var enumFields = enumType.GetFields(BindingFlags.Static | BindingFlags.Public);
            if (!enumFields.Any()) return null;


            var list = new List<(int value, string description)>();
            foreach (var fi in enumFields)
            {
                var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
                //描述
                var description = attributes.Length > 0 ? attributes[0].Description : "";
                //值
                var value = Enum.Parse(enumType, fi.Name).ToInt(int.MinValue);
                if (string.IsNullOrWhiteSpace(description) || value == int.MinValue) continue;

                list.Add((value, description));
            }

            return list;
        }
        
        
        /// <summary>
        /// 根据枚举描述获取枚举值
        /// </summary>
        /// <typeparam name="T">枚举对象</typeparam>
        /// <param name="description">枚举描述</param>
        /// <returns>获取枚举值</returns>
        public static T GetEnumValueByDescription<T>(string description)
        {
            var descriptions = GetAllItemsAndDescriptions<T>();
            foreach (var kv in descriptions)
            {
                if (string.Equals(kv.description, description, StringComparison.OrdinalIgnoreCase))
                {
                    return kv.enumItem;
                }
            }
            return default(T);
        }
    }
}