using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace DAL
{
    public class CommonDAL
    {
        /// <summary>
        /// 获取MD5值
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string GetMD5(string str) {
            byte[] result = Encoding.Default.GetBytes(str);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] output = md5.ComputeHash(result);
            return BitConverter.ToString(output).Replace("-", "");
        }
        
    }
}
