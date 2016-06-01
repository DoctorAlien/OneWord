using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using M = Model;
using D = DAL;
using System.Data.SqlClient;

namespace BLL
{
    public class LoginBLL
    {
        /// <summary>
        /// 判断是否存在该用户
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool IsExist(string username, string password) {
            M.UsersModel user = new M.UsersModel();
            user.Username = username;
            user.Password = password;
            D.LoginDAL dal = new D.LoginDAL();
            return dal.IsExist(user);
        }
        /// <summary>
        /// 判断用户是否已经注册
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public static bool IsRegister(string username) {
            M.UsersModel user = new M.UsersModel();
            user.Username = username;
            D.LoginDAL dal = new D.LoginDAL();
            return dal.IsRegister(user);
        }
        /// <summary>
        /// 判断是否是管理员
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public static bool IsAdmin(string username) {
            M.UsersModel user = new M.UsersModel();
            user.Username = username;
            D.LoginDAL dal = new D.LoginDAL();
            return dal.IsAdmin(user);
        }
        /// <summary>
        /// 获取用户信息数据流
        /// </summary>
        /// <param name="username"></param>
        public static SqlDataReader GetDataReader(string username){
            M.UsersModel user=new M.UsersModel();
            user.Username=username;
            D.LoginDAL dal=new D.LoginDAL();
            return dal.GetDataReader(user);
        }
        /// <summary>
        /// 插入用户
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="mobile"></param>
        /// <returns></returns>
        public static bool InsertUser(string username, string password, string mobile,string create_ip) {
            M.UsersModel user = new M.UsersModel();
            user.Username = username;
            user.Password = password;
            user.Mobile = mobile;
            user.Create_ip = create_ip;
            D.LoginDAL dal = new D.LoginDAL();
            return dal.InsertUser(user);
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool ChangePWD(string username, string password) {
            M.UsersModel user = new M.UsersModel();
            user.Username = username;
            user.Password = password;
            D.LoginDAL dal = new DAL.LoginDAL();
            return dal.ChangePWD(user);
        }
    }
}
