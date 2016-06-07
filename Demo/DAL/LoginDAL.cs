using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using M=Model;
using System.Data.SqlClient;

namespace DAL
{
    public class LoginDAL
    {
        Database sql = new Database();
        /// <summary>
        /// 判断用户是否存在
        /// </summary>
        /// <param name="user"></param>
        /// <param name="admin"></param>
        /// <returns></returns>
        public bool IsExist(M.UsersModel user) {
            try
            {
                string sqlString = "select * from t_users_base where username_=@username and password_=@password and status_=1;";
                SqlParameter[] values = new SqlParameter[]{
                new SqlParameter("@username",user.Username),
                new SqlParameter("@password",user.Password)
                };
                return sql.IsExist(sqlString,values);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        /// <summary>
        /// 判断用户是否已经注册
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool IsRegister(M.UsersModel user) {
            try
            {
                string sqlString = "select * from t_users_base where username_=@username";
                SqlParameter[] values = new SqlParameter[]{
                new SqlParameter("@username",user.Username)
                };
                return sql.IsExist(sqlString, values);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        /// <summary>
        /// 判断用户是否是管理员
        /// </summary>
        /// <param name="user"></param>
        /// <param name="admin"></param>
        /// <returns></returns>
        public bool IsAdmin(M.UsersModel user) {
            try
            {
                string sqlString = "select * from t_users_admin as ua,t_users_base as ub where ua.uuid=ub.uuid and ub.username_=@username and ua.status_=1";
                SqlParameter[] values = new SqlParameter[]{
                new SqlParameter("@username",user.Username)
                };
                return sql.IsExist(sqlString,values);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        /// <summary>
        /// 获取用户信息数据流
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public SqlDataReader GetDataReader(M.UsersModel user) {
            try
            {
                string sqlString = "select * from t_users_base as ub where username_=@username";
                SqlParameter[] values = new SqlParameter[]{
                new SqlParameter("@username",user.Username)
                };
                return sql.GetDataReader(sqlString,values);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        /// <summary>
        /// 插入用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool InsertUser(M.UsersModel user) {
            try
            {
                string sqlString = "insert into t_users_base(username_,password_,mobile_,create_ip)values(@username,@password,@mobile,@createip)";
                SqlParameter[] values = new SqlParameter[]{
                new SqlParameter("@username",user.Username),
                new SqlParameter("@password",user.Password),
                new SqlParameter("@mobile",user.Mobile),
                new SqlParameter("@createip",user.Create_ip)
                };
                int i = sql.UpdateDataRows(sqlString, values);
                if (i == 1)
                {
                    return true;
                }
                else {
                    return false;
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool ChangePWD(M.UsersModel user)
        {
            try
            {
                string sqlString = "update t_users_base set password_=@password where username_=@username";
                SqlParameter[] values = new SqlParameter[]{
                    new SqlParameter("@username",user.Username),
                    new SqlParameter("@password",user.Password)
                };
                int i = sql.UpdateDataRows(sqlString, values);
                if (i == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
