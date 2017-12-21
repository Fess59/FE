using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FlowEngineV1.Tools
{
    public static class Cryptography
    {
        /// <summary>
        /// Конвертирую строку в байт массив шифрованный с помощью SHA256
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private static byte[] StringToSha256ByteArray(string text)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(text);
            SHA256Managed hashstring = new SHA256Managed();
            byte[] hash = hashstring.ComputeHash(bytes);
            return hash;
        }
        /// <summary>
        /// Конвертирую строку в Hash строку шифрованную с помощью SHA256
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string StringToSha256String(string text)
        {
            var hash = StringToSha256ByteArray(text);
            string hashString = string.Empty;
            foreach (byte x in hash)
            {
                hashString += String.Format("{0:x2}", x);
            }
            return hashString;
        }
    }
}
