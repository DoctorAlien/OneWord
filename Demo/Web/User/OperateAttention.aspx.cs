using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_AddAttention : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["uuid"]==null||Session["uuid"].ToString()=="")
        {
            Response.Redirect("../Default.aspx");
        }
        else if (Request.QueryString["uuidto"]==null||Request.QueryString["uuidto"].ToString()=="")
        {
            Response.Redirect("../Default.aspx");
        }
        int uuid_to = int.Parse(Request.QueryString["uuidto"]);
        int uuid_from = int.Parse(Session["uuid"].ToString());

        if (BLL.UserBLL.ExistAttention(uuid_from,uuid_to))
        {
            if (BLL.UserBLL.DeleteAttention(uuid_from,uuid_to))
            {
                Response.Redirect("User.aspx");
            }
            else
            {
                Response.Redirect("User.aspx");
            }
        }
        else
        {
            if (BLL.UserBLL.AddAttention(uuid_from,uuid_to))
            {
                Response.Redirect("MyAttention.aspx");
            }
            else
            {
                Response.Redirect("User.aspx");
            }
        }
    }
}