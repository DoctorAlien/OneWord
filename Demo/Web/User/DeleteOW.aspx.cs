using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_DeleteOW : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] == null || Session["username"].ToString() == "")
        {
            Response.Redirect("../Default.aspx");
        }
        int wbid = int.Parse(Request.QueryString["wbid"]);
        int uuid = int.Parse(Session["uuid"].ToString());
        if (BLL.UserBLL.DeleteMyOW(wbid))
        {
            Response.Redirect("UserCenter.aspx?uuid=" + uuid);
        }
        else {
            Response.Redirect("UserCenter.aspx?uuid=" + uuid);
        }
    }
}