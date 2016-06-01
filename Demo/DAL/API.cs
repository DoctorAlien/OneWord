using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DAL
{
    public class API
    {
        Database sql = new Database();
        public DataSet GetRandomWord() {
            string sqlString = "select top 1 word_,create_time from t_words_base order by NEWID();";
            return sql.GetDataSet(sqlString);
        }
    }
}
