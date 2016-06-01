using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_BanWord : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] == null || Session["username"].ToString() == "")
        {
            Response.Redirect("../Default.aspx");
        }
        int wbid = int.Parse(Request.QueryString["wbid"]);
        if (BLL.AdminBLL.BanWord(wbid))
        {
            Response.Redirect("WordsList.aspx");
        }
        else
        {
            Response.Redirect("WordsList.aspx");
        }
    }
}