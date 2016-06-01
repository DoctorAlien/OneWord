using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class UsersModel
    {
        #region 私有字段
        private int _uuid;
        private string _username;
        private string _password;
        private string _mobile;
        private DateTime _create_time;
        private string _create_ip;
        private int _status;

        #endregion

        #region 封装字段
        public int Uuid
        {
            get { return _uuid; }
            set { _uuid = value; }
        }
        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        public string Mobile
        {
            get { return _mobile; }
            set { _mobile = value; }
        }
        public DateTime Create_time
        {
            get { return _create_time; }
            set { _create_time = value; }
        }
        public string Create_ip
        {
            get { return _create_ip; }
            set { _create_ip = value; }
        }
        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }
        #endregion
    }
}
