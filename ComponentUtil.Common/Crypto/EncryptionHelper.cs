using System;
using System.IO;
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
        /// 获取SHA256 Hash
        /// </summary>
        /// <param name="rawPass"></param>
        /// <param name="salt"></param>
        /// <returns></returns>
        public static string Sha256(string rawPass, object salt = null)
        {
            if (salt != null)
                rawPass = rawPass + "{" + salt + "}";

            var sha256 = SHA256.Create();
            var bs = Encoding.UTF8.GetBytes(rawPass);
            var hs = sha256.ComputeHash(bs);
            var stb = new StringBuilder();
            foreach (var b in hs)
                stb.Append(b.ToString("x2"));

            return stb.ToString();
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

        #region AES加解密

        /// <summary>
        /// AES加密
        /// </summary>
        /// <param name="text">待加密字符串</param>
        /// <param name="iv">偏移</param>
        /// <param name="key">密钥</param>
        /// <returns></returns>
        public static string Aes256Encrypt(string text, string iv, string key)
        {
            var cipher = CreateCipher(key);
            cipher.IV = Convert.FromBase64String(iv);

            var cryptTransform = cipher.CreateEncryptor();
            var plaintext = Encoding.UTF8.GetBytes(text);
            var cipherText = cryptTransform.TransformFinalBlock(plaintext, 0, plaintext.Length);

            return Convert.ToBase64String(cipherText);
        }

        /// <summary>
        /// AES解密
        /// </summary>
        /// <param name="encryptedText">待解密字符串</param>
        /// <param name="iv">偏移</param>
        /// <param name="key">密钥</param>
        /// <returns></returns>
        public static string Aes256Decrypt(string encryptedText, string iv, string key)
        {
            var cipher = CreateCipher(key);
            cipher.IV = Convert.FromBase64String(iv);

            var cryptTransform = cipher.CreateDecryptor();
            var encryptedBytes = Convert.FromBase64String(encryptedText);
            var plainBytes = cryptTransform.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);

            return Encoding.UTF8.GetString(plainBytes);
        }

        /// <summary>
        /// 随机生成AES加解密所需密钥与偏移
        /// </summary>
        /// <returns></returns>
        public static (string Key, string IVBase64) InitSymmetricEncryptionKeyIv()
        {
            var byteArray = new byte[32];
            var randomNumberGenerator = RandomNumberGenerator.Create();
            randomNumberGenerator.GetBytes(byteArray);
            var key = Convert.ToBase64String(byteArray); // 256
            var cipher = CreateCipher(key);
            var ivBase64 = Convert.ToBase64String(cipher.IV);
            return (key, ivBase64);
        }

        private static Aes CreateCipher(string keyBase64)
        {
            // Default values: Keysize 256, Padding PKC27
            var cipher = Aes.Create();
            cipher.Mode = CipherMode.CBC; // Ensure the integrity of the ciphertext if using CBC

            cipher.Padding = PaddingMode.ISO10126;
            cipher.Key = Convert.FromBase64String(keyBase64);

            return cipher;
        }

        private static byte[] GenerateRandomBytes(int length)
        {
            var byteArray = new byte[length];
            var randomNumberGenerator = RandomNumberGenerator.Create();
            randomNumberGenerator.GetBytes(byteArray);
            return byteArray;
        }

        #endregion
    }
}