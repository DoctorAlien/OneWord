using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class WordStatusModel
    {
        #region 私有字段
        private int wsid;
        private int wbid;
        private int number;
        private int status;
        #endregion
        #region 封装字段
        public int Wsid
        {
            get { return wsid; }
            set { wsid = value; }
        }
        public int Wbid
        {
            get { return wbid; }
            set { wbid = value; }
        }
        public int Number
        {
            get { return number; }
            set { number = value; }
        }
        public int Status
        {
            get { return status; }
            set { status = value; }
        }
        #endregion
    }
}
