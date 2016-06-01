using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Admin_Dashboard : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlDataReader sdrUsersNum = BLL.AdminBLL.GetUsersNumReader();
        SqlDataReader sdrWordsNum = BLL.AdminBLL.GetWordsNumReader();
        if (sdrUsersNum.HasRows)
        {
            while (sdrUsersNum.Read())
            {
                lblUsersNumber.Text = sdrUsersNum["count_uuid"].ToString();
            }
        } sdrUsersNum.Close();
        if (sdrWordsNum.HasRows)
        {
            while (sdrWordsNum.Read())
            {
                lblOneWord.Text = sdrWordsNum["count_wbid"].ToString();
            }
        } sdrWordsNum.Close();
    }
}