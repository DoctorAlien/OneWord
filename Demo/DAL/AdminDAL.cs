using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using M=Model;

namespace DAL
{
    public class AdminDAL
    {
        Database sql = new Database();
        /// <summary>
        /// 获取用户数量
        /// </summary>
        /// <returns></returns>
        public SqlDataReader GetUsersNumReader() {
            try
            {
                string sqlString = "select count(ub.uuid) as count_uuid from t_users_base as ub;";
                return sql.GetDataReader(sqlString);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        /// <summary>
        /// 获取OneWord数量
        /// </summary>
        /// <returns></returns>
        public SqlDataReader GetWordsNumReader() {
            try
            {
                string sqlString = "select count(wb.wbid) as count_wbid from t_words_base as wb;";
                return sql.GetDataReader(sqlString);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        /// <summary>
        /// 获取BGM数量
        /// </summary>
        /// <returns></returns>
        public SqlDataReader GetBGMNumReader() {
            try
            {
                string sqlString = "select count(*) as count_bgm from t_musics_base";
                return sql.GetDataReader(sqlString);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <returns></returns>
        public DataSet GetUsersList() {
            try
            {
                string sqlString = "select * from t_users_base";
                return sql.GetDataSet(sqlString);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        /// <summary>
        /// 获取OneWord列表
        /// </summary>
        /// <returns></returns>
        public DataSet GetWordsList() {
            try
            {
                string sqlString = "select * from t_words_base as wb inner join t_users_base as ub on wb.uuid=ub.uuid";
                return sql.GetDataSet(sqlString);
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
                string sqlString = "insert into t_users_base(username_,password_,create_ip)values(@username,@password,@createip);";
                SqlParameter[] values = new SqlParameter[]{
                new SqlParameter("@username",user.Username),
                new SqlParameter("@password",user.Password),
                new SqlParameter("@createip",user.Create_ip)
                };
                int i = sql.UpdateDataRows(sqlString,values);
                if (i==1)
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
        /// <summary>
        /// 获取单个用户信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public SqlDataReader GetUserInfo(M.UsersModel  user) {
            string sqlString = "select * from t_users_base where uuid=@uuid";
            SqlParameter[] values = new SqlParameter[]{
            new SqlParameter("@uuid",user.Uuid)
            };
            return sql.GetDataReader(sqlString, values);
        }
        /// <summary>
        /// 修改单个用户信息(无密码)
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool EditUserNull(M.UsersModel user) {
            string sqlString = "update t_users_base set mobile_=@mobile where uuid=@uuid";
            SqlParameter[] values = new SqlParameter[]{
                new SqlParameter("@uuid",user.Uuid),
                new SqlParameter("@mobile",user.Mobile)
            };
            int i = sql.UpdateDataRows(sqlString, values);
            if (i==1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 修改单个用户信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool EditUser(M.UsersModel user) {
            string sqlString = "update t_users_base set password_=@password,mobile_=@mobile where uuid=@uuid";
            SqlParameter[] values = new SqlParameter[]{
                new SqlParameter("@password",user.Password),
                new SqlParameter("@mobile",user.Mobile),
                new SqlParameter("@uuid",user.Uuid)
            };
            int i = sql.UpdateDataRows(sqlString, values);
            if (i==1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool DeleteUser(M.UsersModel user) {
            string sqlString = "delete from t_users_base where uuid=@uuid";
            SqlParameter[] values = new SqlParameter[]{
                new SqlParameter("@uuid",user.Uuid)
            };
            int i = sql.UpdateDataRows(sqlString, values);
            if (i==1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 禁止OneWord
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public bool BanWord(M.WordsModel word) {
            string sqlString = "update t_words_base set status_=0 where wbid=@wbid";
            SqlParameter[] values = new SqlParameter[]{
                new SqlParameter("@wbid",word.Wbid)
            };
            int i = sql.UpdateDataRows(sqlString, values);
            if (i==1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 开启OneWord
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public bool UnBanWord(M.WordsModel word) {
            string sqlString = "update t_words_base set status_=1 where wbid=@wbid";
            SqlParameter[] values = new SqlParameter[]{
                new SqlParameter("@wbid",word.Wbid)
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
        /// <summary>
        /// 删除OneWord
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public bool DeleteWord(M.WordsModel word) {
            string sqlString = "delete from t_words_base where wbid=@wbid";
            SqlParameter[] values = new SqlParameter[]{
                new SqlParameter("@wbid",word.Wbid)
            };
            int i = sql.UpdateDataRows(sqlString, values);
            if (i==1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 获取歌曲列表
        /// </summary>
        /// <returns></returns>
        public DataSet GetMusicsList() {
            string sqlString = "select * from t_musics_base";
            return sql.GetDataSet(sqlString);
        }
        /// <summary>
        /// 禁用音乐
        /// </summary>
        /// <param name="music"></param>
        /// <returns></returns>
        public bool BanMusic(M.MusicsModel music) {
            string sqlString = "update t_musics_base set status_=0 where mbid=@mbid";
            SqlParameter[] values = new SqlParameter[]{
            new SqlParameter("@mbid",music.Mbid)
            };
            int i = sql.UpdateDataRows(sqlString, values);
            if (i==1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 开启音乐
        /// </summary>
        /// <param name="music"></param>
        /// <returns></returns>
        public bool UnBanMusic(M.MusicsModel music) {
            string sqlString = "update t_musics_base set status_=1 where mbid=@mbid";
            SqlParameter[] values = new SqlParameter[]{
            new SqlParameter("@mbid",music.Mbid)
            };
            int i = sql.UpdateDataRows(sqlString, values);
            if (i==1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 删除音乐
        /// </summary>
        /// <param name="music"></param>
        /// <returns></returns>
        public bool DeleteMusic(M.MusicsModel music) {
            string sqlString = "delete from t_musics_base where mbid=@mbid";
            SqlParameter[] values = new SqlParameter[]{
                new SqlParameter("@mbid",music.Mbid)
            };
            int i = sql.UpdateDataRows(sqlString, values);
            if (i==1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 插入BGM
        /// </summary>
        /// <param name="music"></param>
        /// <returns></returns>
        public bool InsertBGM(M.MusicsModel music) {
            string sqlString = "insert into t_musics_base(title_,author_,url_,picture_)values(@title,@author,@url,@picture)";
            SqlParameter[] values = new SqlParameter[]{
            new SqlParameter("@title",music.Title),
            new SqlParameter("@author",music.Author),
            new SqlParameter("@url",music.Url),
            new SqlParameter("@picture",music.Picture)
            };
            int i = sql.UpdateDataRows(sqlString, values);
            if (i==1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 获取年份值
        /// </summary>
        /// <returns></returns>
        public DataSet GetChartYear() {
            string sqlString = "select DATENAME(YEAR,create_time) as year_ from t_users_base group by DATENAME(YEAR,create_time)";
            return sql.GetDataSet(sqlString);
        }
        /// <summary>
        /// 获取Chart图表 用户统计 
        /// </summary>
        /// <param name="month"></param>
        /// <returns></returns>
        public DataSet GetChartUsers(int month) {
            string sqlString = "select count(*) as sum_people,DATENAME(YEAR,create_time) as year_,DATENAME(MONTH,create_time) as month_ from t_users_base where DATENAME(YEAR,create_time)='"+month+"' group by DATENAME(YEAR,create_time),DATENAME(MONTH,create_time)";
            return sql.GetDataSet(sqlString);
        }
        /// <summary>
        /// 获取Chart图表 一言统计
        /// </summary>
        /// <param name="month"></param>
        /// <returns></returns>
        public DataSet GetChartWords(int month) {
            string sqlString = "select count(*) as sum_word,DATENAME(YEAR,create_time) as year_,DATENAME(MONTH,create_time) as month_ from t_words_base where DATENAME(YEAR,create_time)='" + month + "' group by DATENAME(YEAR,create_time),DATENAME(MONTH,create_time)";
            return sql.GetDataSet(sqlString);
        }
        /// <summary>
        /// 获取关注热度
        /// </summary>
        /// <returns></returns>
        public DataSet GetChartAttention() {
            string sqlString = "select top 3 ub.username_,count(ua.uuid_to) as count_uuid_to from t_users_attention as ua,t_users_base as ub where ua.uuid_to=ub.uuid group by ua.uuid_to,ub.username_ order by count_uuid_to desc;";
            return sql.GetDataSet(sqlString);
        }
    }
}
