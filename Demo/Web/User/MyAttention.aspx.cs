using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class User_MyAttention : System.Web.UI.Page
{
    DataSet dsMyAttention = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        int uuid_from = int.Parse(Session["uuid"].ToString());
        dsMyAttention=BLL.UserBLL.GetMyAttention(uuid_from);
        if (dsMyAttention.Tables.Count>0&&dsMyAttention.Tables[0].Rows.Count>0)
        {
            pnlMyAttentionNull.Visible = false;
            repMyAttention.DataSource = dsMyAttention.Tables[0].DefaultView;
            repMyAttention.DataBind();
        }
        else
        {
            pnlMyAttentionNull.Visible = true;
        }
        
    }
}