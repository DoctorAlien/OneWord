using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using D = DAL;

namespace BLL
{
    public class API
    {
        public static DataSet GetRandomWord()
        {
            D.API dal = new D.API();
            return dal.GetRandomWord();
        }
    }
}
