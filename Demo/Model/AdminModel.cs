using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class AdminModel
    {
        #region 私有字段
        private int _uaid;
        private int _uuid;
        private int _status;
        
        #endregion
        #region 封装字段
        public int Uaid
        {
            get { return _uaid; }
            set { _uaid = value; }
        }
        public int Uuid
        {
            get { return _uuid; }
            set { _uuid = value; }
        }
        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }
        #endregion
    }
}
