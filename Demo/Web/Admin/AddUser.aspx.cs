using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_AddUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnInsert_Click(object sender, EventArgs e)
    {
        string username = txtUserName.Text.Trim();
        string password = BLL.CommonBLL.GetMD5("111111");
        string createip = GetIpAddress();
        if (BLL.AdminBLL.InsertUser(username, password, createip))
        {
            Response.Redirect("UsersList.aspx");
        }
        else
        {
            Response.Redirect("AddUser.aspx");
        }
    }
    /// <summary>
    /// 获取IP地址
    /// </summary>
    /// <returns></returns>
    public static string GetIpAddress()
    {
        string ipAddr = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        if (string.IsNullOrEmpty(ipAddr))
            ipAddr = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];

        if (string.IsNullOrEmpty(ipAddr))
            ipAddr = HttpContext.Current.Request.UserHostAddress;

        return ipAddr;
    }
}