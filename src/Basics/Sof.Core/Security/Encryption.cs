using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Common
{
    public static class Encryption
    {
        /// <summary>
        /// MD5 加密
        /// </summary>
        /// <param name="encryptString">待加密的明文</param>
        /// <returns>加密后的密文</returns>
        public static string MD5Encrypt(string encryptString)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] result = md5.ComputeHash(System.Text.Encoding.Default.GetBytes(encryptString));
            return System.Text.Encoding.Default.GetString(result);
        }
    }
}
