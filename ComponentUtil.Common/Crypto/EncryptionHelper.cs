using System;
using System.Security.Cryptography;
using System.Text;

namespace ComponentUtil.Common.Crypto
{
    public static class EncryptionHelper
    {
        /// <summary>
        ///     HmacSHA256加密
        /// </summary>
        /// <param name="rawPass">源字符串</param>
        /// <param name="key">密钥</param>
        /// <returns></returns>
        private static string HmacSha256(string rawPass, string key)
        {
            var encoding = new UTF8Encoding();
            var keyByte = encoding.GetBytes(key);
            var messageBytes = encoding.GetBytes(rawPass);
            using var hmacSHA256 = new HMACSHA256(keyByte);
            var hashMessage = hmacSHA256.ComputeHash(messageBytes);
            return BitConverter.ToString(hashMessage).Replace("-", "").ToLower();
        }

        /// <summary>
        ///     MD5 加密字符串
        /// </summary>
        /// <param name="rawPass">源字符串</param>
        /// <returns>加密后字符串</returns>
        public static string Md5(string rawPass)
        {
            // 创建MD5类的默认实例：MD5CryptoServiceProvider 
            var md5 = MD5.Create();
            var bs = Encoding.UTF8.GetBytes(rawPass);
            var hs = md5.ComputeHash(bs);
            var stb = new StringBuilder();
            foreach (var b in hs)
                // 以十六进制格式格式化 
                stb.Append(b.ToString("x2"));

            return stb.ToString();
        }

        /// <summary>
        ///     MD5加盐加密
        /// </summary>
        /// <param name="rawPass">源字符串</param>
        /// <param name="salt">盐值</param>
        /// <returns>加密后字符串</returns>
        public static string Md5(string rawPass, object salt)
        {
            return salt == null ? rawPass : Md5(rawPass + "{" + salt + "}");
        }
    }
}