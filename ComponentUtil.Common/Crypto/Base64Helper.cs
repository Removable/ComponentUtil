using System;
using System.Text;

namespace ComponentUtil.Common.Crypto
{
    public static class Base64Helper
    {
        /// <summary>
        ///     将字符串转换成base64格式,使用UTF8字符集
        /// </summary>
        /// <param name="content">加密内容</param>
        /// <returns></returns>
        public static string Base64Encode(string content)
        {
            content = content.Replace('-', '+').Replace('_', '/');
            switch (content.Length % 4)
            {
                case 2:
                    content += "==";
                    break;
                case 3:
                    content += "=";
                    break;
            }

            var bytes = Encoding.UTF8.GetBytes(content);
            return Convert.ToBase64String(bytes);
        }

        /// <summary>
        ///     将base64格式，转换utf8
        /// </summary>
        /// <param name="content">解密内容</param>
        /// <returns></returns>
        public static string Base64Decode(string content)
        {
            var bytes = Convert.FromBase64String(content);
            return Encoding.UTF8.GetString(bytes);
        }
    }
}