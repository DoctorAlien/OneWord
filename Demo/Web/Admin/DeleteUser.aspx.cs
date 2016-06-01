using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_DeleteUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] == null || Session["username"].ToString() == "")
        {
            Response.Redirect("../Default.aspx");
        }
        int uuid = int.Parse(Request.QueryString["uuid"]);
        if (BLL.AdminBLL.DeleteUser(uuid))
        {
            Response.Redirect("UsersList.aspx");
        }
        else
        {
            Response.Redirect("UsersList.aspx");
        }
    }
}