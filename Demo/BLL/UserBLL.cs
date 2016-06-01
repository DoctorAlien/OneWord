using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using M = Model;
using D = DAL;
using System.Data;
using System.Data.SqlClient;

namespace BLL
{
    public class UserBLL
    {
        /// <summary>
        /// 插入OneWord
        /// </summary>
        /// <param name="uuid"></param>
        /// <param name="words"></param>
        /// <returns></returns>
        public static bool InsertWord(int uuid, string words) {
            M.WordsModel word = new M.WordsModel();
            word.Uuid = uuid;
            word.Word = words;
            D.UserDAL dal = new D.UserDAL();
            return dal.InsertWord(word);
        }
        /// <summary>
        /// 获取五个随机OneWord
        /// </summary>
        /// <returns></returns>
        public static DataSet GetWordSet() {
            D.UserDAL dal = new D.UserDAL();
            return dal.GetWordSet();
        }
        /// <summary>
        /// 获取aside信息
        /// </summary>
        /// <param name="uuid"></param>
        /// <returns></returns>
        public static DataSet GetInfoAside(int uuid) {
            M.UsersModel user = new M.UsersModel();
            user.Uuid = uuid;
            D.UserDAL dal = new D.UserDAL();
            return dal.GetInfoAside(user);
        }
        /// <summary>
        /// 获取自己的OneWord
        /// </summary>
        /// <param name="uuid"></param>
        /// <returns></returns>
        public static DataSet GetMyOW(int uuid){
            M.UsersModel user = new M.UsersModel();
            user.Uuid = uuid;
            D.UserDAL dal = new D.UserDAL();
            return dal.GetMyOW(user);
        }
        /// <summary>
        /// 获取自己的基本信息
        /// </summary>
        /// <param name="uuid"></param>
        /// <returns></returns>
        public static SqlDataReader GetMyInfo(int uuid) {
            M.UsersModel user = new M.UsersModel();
            user.Uuid = uuid;
            D.UserDAL dal = new D.UserDAL();
            return dal.GetMyInfo(user);
        }
        /// <summary>
        /// 删除自己的OneWord
        /// </summary>
        /// <param name="wbid"></param>
        /// <returns></returns>
        public static bool DeleteMyOW(int wbid) {
            M.WordsModel word = new M.WordsModel();
            word.Wbid = wbid;
            D.UserDAL dal = new D.UserDAL();
            return dal.DeleteMyOW(word);
        }
        /// <summary>
        /// 查询是否有word_status
        /// </summary>
        /// <param name="wbid"></param>
        /// <returns></returns>
        public static bool ExistWord(int wbid)
        {
            M.WordStatusModel status = new M.WordStatusModel();
            status.Wbid = wbid;
            D.UserDAL dal = new D.UserDAL();
            return dal.ExistWord(status);
        }
        /// <summary>
        /// 插入OneWord状态
        /// </summary>
        /// <param name="wbid"></param>
        /// <returns></returns>
        public static bool InsertStatus(int wbid,int number) {
            M.WordStatusModel status = new M.WordStatusModel();
            status.Wbid = wbid;
            status.Number = number;
            D.UserDAL dal = new D.UserDAL();
            return dal.InsertStatus(status);
        }
        /// <summary>
        /// 编辑OneWord状态
        /// </summary>
        /// <param name="wbid"></param>
        /// <returns></returns>
        public static bool EditStatus(int wbid) {
            M.WordStatusModel status = new M.WordStatusModel();
            status.Wbid = wbid;
            D.UserDAL dal = new D.UserDAL();
            return dal.EditStatus(status);
        }
        /// <summary>
        /// 获取BGM的信息
        /// </summary>
        /// <returns></returns>
        public static DataSet GetMusicInfo() {
            D.UserDAL dal = new D.UserDAL();
            return dal.GetMusicInfo();
        }
        /// <summary>
        /// 获取搜索值
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public static DataSet GetSearchSet(string searchWord, int uuid)
        {
            M.WordsModel word = new M.WordsModel();
            word.Word = searchWord;
            word.Uuid = uuid;
            D.UserDAL dal = new D.UserDAL();
            return dal.GetSearchSet(word);
        }
    }
}
