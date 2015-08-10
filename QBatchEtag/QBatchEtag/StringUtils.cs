using System;
using System.Security.Cryptography;
using System.Text;

namespace QBatchEtag
{

    public class StringUtils
    {
        public static byte[] sha1(byte[] data)
        {
            SHA1 sha1 = new SHA1CryptoServiceProvider();
            return sha1.ComputeHash(data);
        }

        public static string urlSafeBase64Encode(string from)
        {
            return urlSafeBase64Encode(Encoding.UTF8.GetBytes(from));
        }

        public static string urlSafeBase64Encode(byte[] from)
        {
            return Convert.ToBase64String(from).Replace('+', '-').Replace('/', '_');
        }

        public static string urlsafeBase64Decode(string from)
        {
            try
            {
                return Encoding.UTF8.GetString(Convert.FromBase64String(from.Replace('-', '+').Replace('_', '/')));
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static string md5Hash(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] data = Encoding.UTF8.GetBytes(str);
            byte[] hashData = md5.ComputeHash(data);
            StringBuilder sb = new StringBuilder(hashData.Length * 2);
            foreach (byte b in hashData)
            {
                sb.AppendFormat("{0:x2}", b);
            }
            return sb.ToString();
        }
    }
}