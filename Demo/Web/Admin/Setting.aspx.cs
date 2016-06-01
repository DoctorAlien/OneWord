using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Setting : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnChangePassword_Click(object sender, EventArgs e)
    {
        string username = Session["username"].ToString();
        string oldMD5 = BLL.CommonBLL.GetMD5(txtOldPassword.Text.Trim());
        string newMD5 = BLL.CommonBLL.GetMD5(txtNewPassword.Text.Trim());
        Response.Write(username);
        Response.Write(oldMD5);
        Response.Write(newMD5);
        if (BLL.LoginBLL.IsExist(username,oldMD5))
        {

            if (BLL.LoginBLL.ChangePWD(username, newMD5))
            {
                Response.Redirect("../Default.aspx");
            }
            else
            {
                Response.Redirect("Setting.aspx");
            }
        }
    }
}