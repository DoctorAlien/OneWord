using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class WordsModel
    {
        #region 私有字段
        private int _wbid;
        private int _uuid;
        private string _word;
        private DateTime _create_time;
        private int _status;
        #endregion

        #region 封装字段
        public int Wbid
        {
            get { return _wbid; }
            set { _wbid = value; }
        }
        public int Uuid
        {
            get { return _uuid; }
            set { _uuid = value; }
        }
        public string Word
        {
            get { return _word; }
            set { _word = value; }
        }
        public DateTime Create_time
        {
            get { return _create_time; }
            set { _create_time = value; }
        }
        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }
        #endregion
    }
}
