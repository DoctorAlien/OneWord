using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class AttentionModel
    {
        #region 私有字段
        private int _id;
        private int _uuid_from;
        private int _uuid_to;
        private int _status;
        #endregion
        #region 封装字段
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public int Uuid_from
        {
            get { return _uuid_from; }
            set { _uuid_from = value; }
        }
        public int Uuid_to
        {
            get { return _uuid_to; }
            set { _uuid_to = value; }
        }
        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }
        #endregion
    }
}
