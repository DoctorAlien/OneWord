using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class User_UserOW : System.Web.UI.Page
{
    DataSet dsAttentionOW = new DataSet();
    DataSet dsAttentionInfo = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        int uuid_to = int.Parse(Request.QueryString["uuidto"]);
        dsAttentionInfo = BLL.UserBLL.GetAttentionInfo(uuid_to);
        dsAttentionOW=BLL.UserBLL.GetAttentionOW(uuid_to);

        repAttentionInfo.DataSource = dsAttentionInfo.Tables[0].DefaultView; 
        repAttentionInfo.DataBind();

        if (dsAttentionOW.Tables.Count > 0 && dsAttentionOW.Tables[0].Rows.Count > 0)
        {
            repAttentionOW.DataSource = dsAttentionOW.Tables[0].DefaultView;
            repAttentionOW.DataBind();
        }
        else
        {
            pnlAttentionOWNull.Visible = true;
        }
    }
}