using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using D = DAL;

namespace BLL
{
    public class CommonBLL
    {
        /// <summary>
        /// 获取MD5值
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetMD5(string str){
            D.CommonDAL dal = new D.CommonDAL();
            return dal.GetMD5(str);
        }
    }
}
