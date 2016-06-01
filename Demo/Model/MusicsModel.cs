using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class MusicsModel
    {
        #region 私有字段
        private int _mbid;
        private string _title;
        private string _author;
        private string _url;
        private string _picture;
        #endregion
        #region 封装字段
        public int Mbid
        {
            get { return _mbid; }
            set { _mbid = value; }
        }
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        public string Author
        {
            get { return _author; }
            set { _author = value; }
        }
        public string Url
        {
            get { return _url; }
            set { _url = value; }
        }
        public string Picture
        {
            get { return _picture; }
            set { _picture = value; }
        }
        #endregion
    }
}
