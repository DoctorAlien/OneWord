using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace DAL
{
    public class Database
    {
        //链接数据库字段
        private string conString = ConfigurationManager.ConnectionStrings["oneword"].ConnectionString;
        //数据库链接
        private SqlConnection conn = null;
        //数据库查询命令
        private SqlCommand comm = null;
        //填充数据库
        private SqlDataAdapter sda = null;
        //从数据库读取流
        private SqlDataReader sdr = null;
        //数据集
        private DataSet ds = null;
        /// <summary>
        /// 链接数据库
        /// </summary>
        private void OpenConnection()
        {
            if (conn == null)
            {
                conn = new SqlConnection(conString);
            }
            else if (conn.State == ConnectionState.Open)
            {
                return;
            }
            this.conn.Open();
        }
        /// <summary>
        /// 关闭链接数据库
        /// </summary>
        private void CloseConnection()
        {
            conn.Dispose();
            conn.Close();
            conn = null;
        }
        /// <summary>
        /// 查询是否存在数据 返回值 Bool
        /// </summary>
        /// <param name="sqlString"></param>
        /// <returns></returns>
        public bool IsExist(string sqlString)
        {
            OpenConnection();
            comm = new SqlCommand(sqlString, conn);
            sdr = comm.ExecuteReader();
            try
            {
                if (sdr.Read())
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
            finally
            {
                CloseConnection();
            }
        }
        /// <summary>
        /// 重载 查询是否存在数据 返回值Bool
        /// </summary>
        /// <param name="sqlString"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public bool IsExist(string sqlString, SqlParameter[] values)
        {
            OpenConnection();
            comm = new SqlCommand(sqlString, conn);
            foreach (SqlParameter item in values)
            {
                comm.Parameters.Add(item);
            }
            sdr = comm.ExecuteReader();
            try
            {
                if (sdr.Read())
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
            finally
            {
                CloseConnection();
            }
        }
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="sqlString">sql语句</param>
        public void UpdateData(string sqlString)
        {
            OpenConnection();
            comm = new SqlCommand(sqlString, conn);
            comm.ExecuteNonQuery();
            CloseConnection();
        }
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="sqlString">sql语句</param>
        /// <param name="values">更新数组</param>
        public void UpdateData(string sqlString, SqlParameter[] values)
        {
            OpenConnection();
            comm = new SqlCommand(sqlString, conn);
            foreach (SqlParameter item in values)
            {
                comm.Parameters.Add(item);
            }
            comm.ExecuteNonQuery();
            CloseConnection();
        }
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="sqlString">sql语句</param>
        /// <returns>返回更新行数</returns>
        public int UpdateDataRows(string sqlString)
        {
            OpenConnection();
            comm = new SqlCommand(sqlString, conn);
            int i = comm.ExecuteNonQuery();
            CloseConnection();
            return i;
        }
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="sqlString">sql语句</param>
        /// <param name="values">更新数组</param>
        /// <returns>返回更新行数</returns>
        public int UpdateDataRows(string sqlString, SqlParameter[] values)
        {
            OpenConnection();
            comm = new SqlCommand(sqlString, conn);
            foreach (SqlParameter item in values)
            {
                comm.Parameters.Add(item);
            }
            int i = comm.ExecuteNonQuery();
            CloseConnection();
            return i;
        }
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="sqlString">sql语句</param>
        /// <returns>返回数据集</returns>
        public SqlDataAdapter UpdateDataSet(string sqlString)
        {
            OpenConnection();
            comm = new SqlCommand(sqlString, conn);
            ds = new DataSet();
            sda = new SqlDataAdapter(comm);
            SqlCommandBuilder scb = new SqlCommandBuilder(sda);
            CloseConnection();
            return sda;
        }
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="sqlString">sql语句</param>
        /// <param name="values">更新数组</param>
        /// <returns>返回数据集</returns>
        public SqlDataAdapter UpdateDataSet(string sqlString, SqlParameter[] values)
        {
            OpenConnection();
            comm = new SqlCommand(sqlString, conn);
            foreach (SqlParameter item in values)
            {
                comm.Parameters.Add(item);
            }
            ds = new DataSet();
            sda = new SqlDataAdapter(comm);
            SqlCommandBuilder scb = new SqlCommandBuilder(sda);
            CloseConnection();
            return sda;
        }
        /// <summary>
        /// 获取数据集
        /// </summary>
        /// <param name="sqlString">sql语句</param>
        /// <returns>返回数据集</returns>
        public DataSet GetDataSet(String sqlString)
        {
            OpenConnection();
            comm = new SqlCommand(sqlString, conn);
            ds = new DataSet();
            sda = new SqlDataAdapter(comm);
            sda.Fill(ds);
            CloseConnection();
            return ds;
        }
        /// <summary>
        /// 获取数据集
        /// </summary>
        /// <param name="sqlString">sql语句</param>
        /// <param name="values">更新数组</param>
        /// <returns>返回数据集</returns>
        public DataSet GetDataSet(String sqlString, SqlParameter[] values)
        {
            OpenConnection();
            comm = new SqlCommand(sqlString, conn);
            foreach (SqlParameter item in values)
            {
                comm.Parameters.Add(item);
            }
            ds = new DataSet();
            sda = new SqlDataAdapter(comm);
            sda.Fill(ds);
            CloseConnection();
            return ds;
        }
        /// <summary>
        /// 获取数据流
        /// </summary>
        /// <param name="sqlString">sql语句</param>
        /// <returns>返回数据流</returns>
        public SqlDataReader GetDataReader(string sqlString)
        {
            OpenConnection();
            comm = new SqlCommand(sqlString, conn);
            SqlDataReader sdr = comm.ExecuteReader();
            return sdr;
        }
        /// <summary>
        /// 获取数据流
        /// </summary>
        /// <param name="sqlString">sql语句</param>
        /// <param name="values">更新数组</param>
        /// <returns>返回数据流</returns>
        public SqlDataReader GetDataReader(string sqlString, SqlParameter[] values)
        {
            OpenConnection();
            comm = new SqlCommand(sqlString, conn);
            foreach (SqlParameter item in values)
            {
                comm.Parameters.Add(item);
            }
            SqlDataReader sdr = comm.ExecuteReader();
            return sdr;
        }
    }
}
