using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class User_index : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] == null || Session["username"].ToString() == "")
        {
            Response.Redirect("../Default.aspx");
        }
        if (Session["uuid"] == null || Session["uuid"].ToString() == "")
        {
            Response.Redirect("../Default.aspx");
        }
        repMusic.DataSource = BLL.UserBLL.GetMusicInfo().Tables[0].DefaultView;
        repMusic.DataBind();
    }
}
