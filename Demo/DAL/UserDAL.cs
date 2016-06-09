using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using M=Model;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class UserDAL
    {
        Database sql = new Database();
        /// <summary>
        /// 插入OneWord
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public bool InsertWord(M.WordsModel word) {
            string sqlString = "insert into t_words_base(uuid,word_)values(@uuid,@word)";
            SqlParameter[] values = new SqlParameter[]{
            new SqlParameter("@uuid",word.Uuid),
            new SqlParameter("@word",word.Word)
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
        /// 获取五个随机OneWord
        /// </summary>
        /// <returns></returns>
        public DataSet GetWordSet() {
            string sqlString = "select top 5 * from t_words_base as wb inner join t_users_base as ub on (wb.uuid=ub.uuid and wb.status_=1) left join t_words_status as ws on (wb.wbid=ws.wbid)  order by NEWID();";
            return sql.GetDataSet(sqlString);
        }
        /// <summary>
        /// 获取aside信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public DataSet GetInfoAside(M.UsersModel user) {
            string sqlString = "select sum(a1.count_words) as count_words_a1,sum(a1.sum_number) as sum_number_a1,a1.uuid,a1.username_ from (select ub.uuid,count(wb.uuid) as count_words,sum(ws.number_) as sum_number,ub.username_ from t_words_base as wb left join t_words_status as ws on wb.wbid=ws.wbid left join t_users_base as ub on ub.uuid=wb.uuid group by wb.uuid,ws.number_,ub.username_,ub.uuid having wb.uuid=@uuid)as a1 group by a1.uuid,a1.username_;";
            SqlParameter[] values = new SqlParameter[]{
            new SqlParameter("@uuid",user.Uuid)
            };
            return sql.GetDataSet(sqlString,values);
        }
        /// <summary>
        /// 获取自己的OneWord
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public DataSet GetMyOW(M.UsersModel user) {
            string sqlString = "select * from t_words_base as wb,t_users_base as ub where ub.uuid=wb.uuid and ub.uuid=@uuid;";
            SqlParameter[] values = new SqlParameter[]{
                new SqlParameter("@uuid",user.Uuid)
            };
            return sql.GetDataSet(sqlString, values);
        }
        /// <summary>
        /// 获取自己的基本信息
        /// </summary>
        /// <returns></returns>
        public SqlDataReader GetMyInfo(M.UsersModel user) {
            string sqlString = "select * from t_users_base where uuid=@uuid";
            SqlParameter[] values = new SqlParameter[]{
                new SqlParameter("@uuid",user.Uuid)
            };
            return sql.GetDataReader(sqlString,values);
        }
        /// <summary>
        /// 删除自己的OneWord
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public bool DeleteMyOW(M.WordsModel word) {
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
        /// 查询是否有word_status
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public bool ExistWord(M.WordStatusModel status)
        {
            string sqlString = "select * from t_words_status where wbid=@wbid";
            SqlParameter[] values = new SqlParameter[]{
                new SqlParameter("@wbid",status.Wbid)
            };
            if (sql.IsExist(sqlString, values))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 插入OneWord状态
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public bool InsertStatus(M.WordStatusModel status) {
            string sqlString = "insert into t_words_status(wbid,number_)values(@wbid,@number)";
            SqlParameter[] values = new SqlParameter[]{
                new SqlParameter("@wbid",status.Wbid),
                new SqlParameter("@number",status.Number)
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
        /// 编辑OneWord状态
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public bool EditStatus(M.WordStatusModel status) {
            string sqlString = "update t_words_status set number_ =(number_+1) where wbid=@wbid";
            SqlParameter[] values = new SqlParameter[]{
                new SqlParameter("@wbid",status.Wbid)
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
        /// 获取BGM的信息
        /// </summary>
        /// <returns></returns>
        public DataSet GetMusicInfo() {
            string sqlString = "select top 1 * from t_musics_base where status_=1 order by NEWID()";
            return sql.GetDataSet(sqlString);
        }
        /// <summary>
        /// 获取搜索值
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public DataSet GetSearchSet(M.WordsModel word)
        {
            string sqlString = "select * from t_words_base as wb,t_users_base as ub where word_ like '%" + word.Word + "%'and ub.uuid=wb.uuid and ub.uuid=" + word.Uuid;
            //SqlParameter[] values = new SqlParameter[]{
            //    new SqlParameter("@word",word.Word),
            //    new SqlParameter("@uuid",word.Uuid)
            //};
            return sql.GetDataSet(sqlString);
        }
        /// <summary>
        /// 是否已经关注过
        /// </summary>
        /// <param name="attention"></param>
        /// <returns></returns>
        public bool ExistAttention(M.AttentionModel attention) {
            try
            {
                string sqlString = "select * from t_users_attention where uuid_from=@uuid_from and uuid_to=@uuid_to ";
                SqlParameter[] values = new SqlParameter[]{
                new SqlParameter("@uuid_from",attention.Uuid_from),
                new SqlParameter("@uuid_to",attention.Uuid_to)
                };
                return sql.IsExist(sqlString,values);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        /// <summary>
        /// 添加关注
        /// </summary>
        /// <param name="attention"></param>
        /// <returns></returns>
        public bool AddAttention(M.AttentionModel attention) {
            try
            {
                string sqlString = "insert into t_users_attention(uuid_from,uuid_to) values(@uuid_from,@uuid_to)";
                SqlParameter[] values = new SqlParameter[]{
                new SqlParameter("@uuid_from",attention.Uuid_from),
                new SqlParameter("@uuid_to",attention.Uuid_to)
                };
                int i = sql.UpdateDataRows(sqlString,values);
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
        /// <summary>
        /// 删除关注
        /// </summary>
        /// <param name="attention"></param>
        /// <returns></returns>
        public bool DeleteAttention(M.AttentionModel attention) {
            try
            {
                string sqlString = "delete from t_users_attention where uuid_from=@uuid_from and uuid_to=@uuid_to";
                SqlParameter[] values = new SqlParameter[]{
                new SqlParameter("@uuid_from",attention.Uuid_from),
                new SqlParameter("@uuid_to",attention.Uuid_to)
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
        /// 获取用户的关注列表
        /// </summary>
        /// <param name="attention"></param>
        /// <returns></returns>
        public DataSet GetMyAttention(M.AttentionModel attention) {
            string sqlString = "select * from t_users_attention as ua,t_users_base as ub where ua.uuid_to=ub.uuid and ua.uuid_from=@uuid_from";
            SqlParameter[] values = new SqlParameter[]{
            new SqlParameter("@uuid_from",attention.Uuid_from)
            };
            return sql.GetDataSet(sqlString,values);
        }
        /// <summary>
        /// 获取关注者的OneWord
        /// </summary>
        /// <param name="attention"></param>
        /// <returns></returns>
        public DataSet GetAttentionOW(M.AttentionModel attention) {
            string sqlString = "select * from t_words_base as wb where wb.uuid=@uuid_to";
            SqlParameter[] values = new SqlParameter[]{
            new SqlParameter("@uuid_to",attention.Uuid_to)
            };
            return sql.GetDataSet(sqlString, values);
        }
        /// <summary>
        /// 获取关注者基本信息
        /// </summary>
        /// <param name="attention"></param>
        /// <returns></returns>
        public DataSet GetAttentionInfo(M.AttentionModel attention) {
            string sqlString = "select * from t_users_base where uuid=@uuid_to";
            SqlParameter[] values = new SqlParameter[]{
            new SqlParameter("@uuid_to",attention.Uuid_to)
            };
            return sql.GetDataSet(sqlString, values);
        }
        /// <summary>
        /// 获取今日推荐
        /// </summary>
        /// <param name="attention"></param>
        /// <returns></returns>
        public DataSet GetAttentionRandom(M.AttentionModel attention) {
            string sqlString = "select top 3 * from t_users_base as ub where ub.uuid not in(select ua.uuid_to from t_users_attention as ua where ua.uuid_from=@uuid_from) order by NEWID()";
            SqlParameter[] values = new SqlParameter[]{
            new SqlParameter("@uuid_from",attention.Uuid_from)
            };
            return sql.GetDataSet(sqlString, values);
        }
    }
}
