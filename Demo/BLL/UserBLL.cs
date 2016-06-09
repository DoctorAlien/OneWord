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
        /// <summary>
        /// 是否已经关注过
        /// </summary>
        /// <returns></returns>
        public static bool ExistAttention(int uuid_from, int uuid_to){
            M.AttentionModel attention = new M.AttentionModel();
            attention.Uuid_from = uuid_from;
            attention.Uuid_to = uuid_to;
            D.UserDAL dal = new D.UserDAL();
            return dal.ExistAttention(attention);
        }
        /// <summary>
        /// 添加关注
        /// </summary>
        /// <param name="uuid_from"></param>
        /// <param name="uuid_to"></param>
        /// <returns></returns>
        public static bool AddAttention(int uuid_from,int uuid_to) {
            M.AttentionModel attention = new M.AttentionModel();
            attention.Uuid_from = uuid_from;
            attention.Uuid_to = uuid_to;
            D.UserDAL dal = new D.UserDAL();
            return dal.AddAttention(attention);
        }
        /// <summary>
        /// 删除关注
        /// </summary>
        /// <param name="uuid_from"></param>
        /// <param name="uuid_to"></param>
        /// <returns></returns>
        public static bool DeleteAttention(int uuid_from, int uuid_to) {
            M.AttentionModel attention = new M.AttentionModel();
            attention.Uuid_from = uuid_from;
            attention.Uuid_to = uuid_to;
            D.UserDAL dal = new D.UserDAL();
            return dal.DeleteAttention(attention);
        }
        /// <summary>
        /// 获取用户的关注列表
        /// </summary>
        /// <param name="uuid_from"></param>
        /// <returns></returns>
        public static DataSet GetMyAttention(int uuid_from) {
            M.AttentionModel attention = new M.AttentionModel();
            attention.Uuid_from = uuid_from;
            D.UserDAL dal = new D.UserDAL();
            return dal.GetMyAttention(attention);
        }
        /// <summary>
        /// 获取关注者的OneWord
        /// </summary>
        /// <param name="uuid_to"></param>
        /// <returns></returns>
        public static DataSet GetAttentionOW(int uuid_to) {
            M.AttentionModel attention = new M.AttentionModel();
            attention.Uuid_to = uuid_to;
            D.UserDAL dal = new D.UserDAL();
            return dal.GetAttentionOW(attention);
        }
        /// <summary>
        /// 获取关注者基本信息
        /// </summary>
        /// <param name="uuid_to"></param>
        /// <returns></returns>
        public static DataSet GetAttentionInfo(int uuid_to) {
            M.AttentionModel attention = new M.AttentionModel();
            attention.Uuid_to = uuid_to;
            D.UserDAL dal = new D.UserDAL();
            return dal.GetAttentionInfo(attention);
        }
        /// <summary>
        /// 获取今日推荐
        /// </summary>
        /// <param name="uuid_from"></param>
        /// <returns></returns>
        public static DataSet GetAttentionRandom(int uuid_from) {
            M.AttentionModel attention = new M.AttentionModel();
            attention.Uuid_from = uuid_from;
            D.UserDAL dal = new D.UserDAL();
            return dal.GetAttentionRandom(attention);
        }
    }
}
