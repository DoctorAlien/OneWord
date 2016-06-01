using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using D = DAL;
using M = Model;
using System.Data;

namespace BLL
{
    public class AdminBLL
    {
        /// <summary>
        /// 获取用户数量
        /// </summary>
        /// <returns></returns>
        public static SqlDataReader GetUsersNumReader() {
            D.AdminDAL dal = new D.AdminDAL();
            return dal.GetUsersNumReader();
        }
        /// <summary>
        /// 获取OneWord数量
        /// </summary>
        /// <returns></returns>
        public static SqlDataReader GetWordsNumReader() {
            D.AdminDAL dal = new D.AdminDAL();
            return dal.GetWordsNumReader();
        }
        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <returns></returns>
        public static DataSet GetUsersList() {
            D.AdminDAL dal = new D.AdminDAL();
            return dal.GetUsersList();
        }
        /// <summary>
        /// 获取OneWord列表
        /// </summary>
        /// <returns></returns>
        public static DataSet GetWordsList() {
            D.AdminDAL dal = new D.AdminDAL();
            return dal.GetWordsList();
        }
        /// <summary>
        /// 插入用户
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool InsertUser(string username, string password, string createip){
            M.UsersModel user = new M.UsersModel();
            user.Username = username;
            user.Password = password;
            user.Create_ip = createip;
            D.AdminDAL dal = new D.AdminDAL();
            return dal.InsertUser(user);
        }
        /// <summary>
        /// 获取单个用户信息
        /// </summary>
        /// <param name="uuid"></param>
        /// <returns></returns>
        public static SqlDataReader GetUserInfo(int uuid) {
            M.UsersModel user = new M.UsersModel();
            user.Uuid = uuid;
            D.AdminDAL dal = new D.AdminDAL();
            return dal.GetUserInfo(user);
        }
        /// <summary>
        /// 修改单个用户信息(无密码)
        /// </summary>
        /// <param name="mobile"></param>
        /// <returns></returns>
        public static bool EditUserNull(string mobile,int uuid) {
            M.UsersModel user = new M.UsersModel();
            user.Mobile = mobile;
            user.Uuid = uuid;
            D.AdminDAL dal = new D.AdminDAL();
            return dal.EditUserNull(user);
        }
        /// <summary>
        /// 修改单个用户信息
        /// </summary>
        /// <param name="password"></param>
        /// <param name="mobile"></param>
        /// <returns></returns>
        public static bool EditUser(string password, string mobile,int uuid) {
            M.UsersModel user = new M.UsersModel();
            user.Password = password;
            user.Mobile = mobile;
            user.Uuid = uuid;
            D.AdminDAL dal = new D.AdminDAL();
            return dal.EditUser(user);
        }
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="uuid"></param>
        /// <returns></returns>
        public static bool DeleteUser(int uuid) {
            M.UsersModel user = new M.UsersModel();
            user.Uuid = uuid;
            D.AdminDAL dal = new D.AdminDAL();
            return dal.DeleteUser(user);
        }
        /// <summary>
        /// 禁止OneWord
        /// </summary>
        /// <returns></returns>
        public static bool BanWord(int wbid) {
            M.WordsModel word = new M.WordsModel();
            word.Wbid = wbid;
            D.AdminDAL dal = new D.AdminDAL();
            return dal.BanWord(word);
        }
        /// <summary>
        /// 开启OneWord
        /// </summary>
        /// <returns></returns>
        public static bool UnBanWord(int wbid) {
            M.WordsModel word = new M.WordsModel();
            word.Wbid = wbid;
            D.AdminDAL dal = new D.AdminDAL();
            return dal.UnBanWord(word);
        }
        /// <summary>
        /// 删除OneWord
        /// </summary>
        /// <returns></returns>
        public static bool DeleteWord(int wbid) {
            M.WordsModel word = new M.WordsModel();
            word.Wbid = wbid;
            D.AdminDAL dal = new D.AdminDAL();
            return dal.DeleteWord(word);
        }
        /// <summary>
        /// 获取歌曲列表
        /// </summary>
        /// <returns></returns>
        public static DataSet GetMusicsList(){
            D.AdminDAL dal = new D.AdminDAL();
            return dal.GetMusicsList();
        }
        /// <summary>
        /// 禁用音乐
        /// </summary>
        /// <param name="mbid"></param>
        /// <returns></returns>
        public static bool BanMusic(int mbid)
        {
            M.MusicsModel music = new M.MusicsModel();
            music.Mbid = mbid;
            D.AdminDAL dal = new D.AdminDAL();
            return dal.BanMusic(music);
        }
        /// <summary>
        /// 开启音乐
        /// </summary>
        /// <param name="mbid"></param>
        /// <returns></returns>
        public static bool UnBanMusic(int mbid)
        {
            M.MusicsModel music = new M.MusicsModel();
            music.Mbid = mbid;
            D.AdminDAL dal = new D.AdminDAL();
            return dal.UnBanMusic(music);
        }
        /// <summary>
        /// 删除音乐
        /// </summary>
        /// <param name="mbid"></param>
        /// <returns></returns>
        public static bool DeleteMusic(int mbid)
        {
            M.MusicsModel music = new M.MusicsModel();
            music.Mbid = mbid;
            D.AdminDAL dal = new D.AdminDAL();
            return dal.DeleteMusic(music);
        }
        public static bool InsertBGM(string title, string author, string url, string picture) {
            M.MusicsModel music = new M.MusicsModel();
            music.Author = author;
            music.Title = title;
            music.Url = url;
            music.Picture = picture;
            D.AdminDAL dal = new D.AdminDAL();
            return dal.InsertBGM(music);
        }
    }
}
