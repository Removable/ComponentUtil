using System;
using System.IO;
using System.Xml.Serialization;

namespace ComponentUtil.Common.Data
{
    public class XmlHelper
    {
        /// <summary>
        /// XML序列化
        /// </summary>
        /// <typeparam name="T">类名</typeparam>
        /// <param name="obj">T类名的实例</param>
        /// <returns></returns>
        public static string XmlSerialize<T>(T obj)
        {
            using var sw = new StringWriter();
            var serializer = new XmlSerializer(obj.GetType());
            serializer.Serialize(sw, obj);
            sw.Close();
            return sw.ToString();
        }
        
        /// <summary>
        /// XML反序列化
        /// </summary>
        /// <typeparam name="T">对应的类</typeparam>
        /// <param name="xmlString">XML字符串</param>
        /// <returns></returns>
        public static T XmlDeserializer<T>(string xmlString) where T : class
        {
            try
            {
                using var sr = new StringReader(xmlString);
                var serializer = new XmlSerializer(typeof(T));
                return serializer.Deserialize(sr) as T;
            }
            catch
            {
                return null;
            }
        }

    }
}