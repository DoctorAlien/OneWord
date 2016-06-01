using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Admin_EditUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            int uuid = int.Parse(Request.QueryString["uuid"]);
            txtUUID.Text = uuid.ToString();

            SqlDataReader sdrUserInfo = BLL.AdminBLL.GetUserInfo(uuid);
            if (sdrUserInfo.HasRows)
            {
                while (sdrUserInfo.Read())
                {
                    txtUserName.Text = sdrUserInfo["username_"].ToString();
                    txtMobile.Text = sdrUserInfo["mobile_"].ToString();
                    txtCreateTime.Text = sdrUserInfo["create_time"].ToString();
                    txtCreateIP.Text = sdrUserInfo["create_ip"].ToString();
                }
            } sdrUserInfo.Close();
        }
    }
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        string password = txtPassword.Text.Trim();
        string mobile = txtMobile.Text.Trim();
        int uuid = int.Parse(txtUUID.Text);
        if (password == null || password == "")
        {
            if (BLL.AdminBLL.EditUserNull(mobile, uuid))
            {
                Response.Redirect("UsersList.aspx");
            }
        }
        else
        {
            if (BLL.AdminBLL.EditUser(BLL.CommonBLL.GetMD5(password), mobile, uuid))
            {

                Response.Redirect("UsersList.aspx");
            }
        }
    }
}