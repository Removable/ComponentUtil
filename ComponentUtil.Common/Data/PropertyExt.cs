using System.ComponentModel;
using System.Reflection;

namespace ComponentUtil.Common.Data
{
    public static class PropertyExt
    {
        /// <summary>
        ///     获取属性的描述
        /// </summary>
        /// <param name="value">属性</param>
        /// <returns>描述</returns>
        public static string GetDescription(this PropertyInfo value)
        {
            var d = (DescriptionAttribute[]) value.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return d.Length > 0 ? d[0].Description : "";
        }

        /// <summary>
        /// 通过属性名称反射获取属性值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="propertyName">属性名称</param>
        /// <returns></returns>
        public static object GetPropertyByName<T>(this T obj, string propertyName)
        {
            var type = typeof(T);
            var property = type.GetProperty(propertyName);
            if (property == null) return string.Empty;

            var o = property.GetValue(obj, null);

            return o ?? string.Empty;
        }
    }
}