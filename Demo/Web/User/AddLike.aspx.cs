using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_AddLike : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] == null || Session["username"].ToString() == "")
        {
            Response.Redirect("../Default.aspx");
        }
        int wbid = int.Parse(Request.QueryString["wbid"]);
        if (BLL.UserBLL.ExistWord(wbid))
        {
            if (BLL.UserBLL.EditStatus(wbid))
            {
                Response.Redirect("User.aspx");
            }
        } 
        else
        {
            if (BLL.UserBLL.InsertStatus(wbid,1))
            {
                Response.Redirect("User.aspx");
            }
        }
    }
}